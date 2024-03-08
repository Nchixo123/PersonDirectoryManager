using DTOs;
using Services.RepositoryInterfaces;


namespace Db.Repository;

internal sealed class CityRepostiroy : RepositoryBase<City>, ICityRepository
{
    internal CityRepostiroy(PersonDbContext context) : base(context)
    {

    }
}
