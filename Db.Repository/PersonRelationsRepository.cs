using DTOs;
using Services.RepositoryInterfaces;

namespace Db.Repository;

internal sealed class PersonRelationsRepository : RepositoryBase<PersonRelations>, IPersonRelationsRepository
{
    internal PersonRelationsRepository(PersonDbContext context) : base(context)
    {

    }
}
