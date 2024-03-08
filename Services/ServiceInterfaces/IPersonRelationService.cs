using DTOs;
using System.Security.Cryptography;

namespace Services.ServiceInterfaces;

public interface IPersonRelationService
{
    Task<ICollection<Person>> GetRelationships(int fromId, int toId);
    void UpdateRelationship(int fromId, int ToId);
}
