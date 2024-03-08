using DTOs;

namespace Services.ServiceInterfaces;

public interface ICityService
{
    Task<City> GetCity(int cityId);
    Task<IQueryable<City>> GetCities();
    void AddCity(City city);
    void UpdateCity(City city);
    void DeleteCity(int cityId);
}
