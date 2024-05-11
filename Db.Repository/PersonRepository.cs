using DTOs;
using Services.RepositoryInterfaces;

namespace Db.Repository;

internal sealed class PersonRepository : RepositoryBase<Person>, IPersonRepository
{
    internal PersonRepository(PersonDbContext context) : base(context)
    {
        
    }
}
