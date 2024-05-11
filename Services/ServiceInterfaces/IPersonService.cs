using DTOs;

namespace Services.ServiceInterfaces;

public interface IPersonService
{
    Task<Person> GetPerson(int Id);
    Task<IEnumerable<Person>> GetPeople();
    void AddPerson(Person person);
    void UpdatePerson(Person person);
    void DeletePerson(int Id);
}
