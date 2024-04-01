using DTOs;
using Services.RepositoryInterfaces;


namespace Db.Repository;

internal sealed class CityRepository : RepositoryBase<City>, ICityRepository
{
    internal CityRepository(PersonDbContext context) : base(context)
    {

    }
}
