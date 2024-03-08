using DTOs;

namespace Services.ServiceInterfaces;

public interface IPersonService
{
    Task<Person> GetPerson(int Id);
    Task<IQueryable<Person>> GetPeople();
    void AddPerson(Person person);
    void UpdatePerson(Person person);
    void DeletePerson(int Id);
}
