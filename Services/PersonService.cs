using DTOs;
using Services.RepositoryInterfaces;
using Services.ServiceInterfaces;

namespace Services;

public sealed class PersonService : IPersonService
{
    private readonly IUnitOfWork _unitOfWork;

    public PersonService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public void AddPerson(Person person)
    {
        if (person == null) throw new ArgumentNullException(nameof(person));
        _unitOfWork.PersonRepository.Insert(person);
        _unitOfWork.SaveChanges();
    }

    public void DeletePerson(int id)
    {
        Person person = _unitOfWork.PersonRepository.Get(id) ?? throw new ArgumentNullException("The Given Id does not exist");
        person.IsDelete = true;
        _unitOfWork.PersonRepository.Update(person);
        _unitOfWork.SaveChanges();
    }

    public async Task<IEnumerable<Person>> GetPeople()
    {
        var people = await _unitOfWork.PersonRepository.SetAsync();
        return people;
    }

    public async Task<Person> GetPerson(int id)
    {
        return await _unitOfWork.PersonRepository.GetAsync(id);
    }

    public void UpdatePerson(Person person)
    {
        if (person == null) throw new ArgumentNullException(nameof(person));
        _unitOfWork.PersonRepository.Update(person);
        _unitOfWork.SaveChanges();
    }
}
