using DTOs;
using Services.ServiceInterfaces;

namespace Services;

public sealed class PersonRelationsService : IPersonRelationService
{
    public Task<ICollection<Person>> GetRelationships(int fromId, int toId)
    {
        throw new NotImplementedException();
    }

    public void UpdateRelationship(int fromId, int ToId)
    {
        throw new NotImplementedException();
    }
}
