using DTOs;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.ServiceInterfaces;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly IPersonService _personService;
    private readonly ILogger<PersonController> _logger;

    public PersonController(IPersonService personService, ILogger<PersonController> logger)
    {
        _personService = personService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<Person> GetPerson(int id)
    {
        _logger.LogInformation($"Getting person with ID: {id}");
        var person = await _personService.GetPerson(id);
        if (person == null)
        {
            _logger.LogWarning($"No person found with ID: {id}");
            throw new Exception(nameof(id));
        }
        _logger.LogInformation($"Successfully retrieved person with ID: {id}");
        return person;
    }

    [HttpGet]
    public async Task<IEnumerable<Person>> GetPeople()
    {
        _logger.LogInformation("Getting all people");
        var people = await _personService.GetPeople();
        if (people == null || !people.Any())
        {
            _logger.LogWarning("No people found in the database");
            throw new ArgumentNullException("There are no people in the database");
        }
        _logger.LogInformation($"Successfully retrieved {people.Count()} people");
        return people;
    }

    [HttpPost]
    public void AddPerson(PersonModel model)
    {
        if(model is null)
        {
            _logger.LogWarning("The data to Add a new person to the database was not provided properly");
            throw new ArgumentNullException();
        }

        _logger.LogInformation("Adding a new person to the database");
        Person newPerson = new()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Address = model.Address,
            Gender = (Gender)model.Gender,
            BirthDate = model.BirthDate,
            PIN = model.PIN,
            PersonalNumber = model.PersonalNumber
        };
        _personService.AddPerson(newPerson);
        _logger.LogInformation($"{newPerson.FirstName} {newPerson.LastName} Added succesfully to the database");
    }

    [HttpPut]
    public void UpdatePerson(PersonModel model)
    {
        if (model is null)
        {
            _logger.LogWarning("The data to update a person to the database was not provided properly");
            throw new ArgumentNullException();
        }

        _logger.LogInformation("updating person in the database");
        Person newPerson = new()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Address = model.Address,
            Gender = (Gender)model.Gender,
            BirthDate = model.BirthDate,
            PIN = model.PIN,
            PersonalNumber = model.PersonalNumber
        };
        _personService.UpdatePerson(newPerson);
        _logger.LogInformation($"{newPerson.FirstName} {newPerson.LastName} updated succesfully in the database");
    }

    [HttpDelete]
    public void DeletePerson(int id)
    {
        _logger.LogInformation($"Deleting a person with the ID:{id}");
        _personService.DeletePerson(id);
    }
}
