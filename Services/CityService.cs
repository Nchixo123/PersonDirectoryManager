using DTOs;
using Services.RepositoryInterfaces;
using Services.ServiceInterfaces;

namespace Services;

public sealed class CityService : ICityService
{
    private readonly IUnitOfWork _unitOfWork;

    public CityService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public void AddCity(City city)
    {
        if (city == null) throw new ArgumentNullException(nameof(city));
        _unitOfWork.CityRepository.Insert(city);
        _unitOfWork.SaveChanges();
    }

    public void DeleteCity(int cityId)
    {
        City city = _unitOfWork.CityRepository.Get(cityId) ?? throw new ArgumentNullException("The Given Id does not exist");
        city.IsDelete = true;
        _unitOfWork.CityRepository.Update(city);
        _unitOfWork.SaveChanges();
    }

    public async Task<IQueryable<City>> GetCities()
    {
        var cities = await _unitOfWork.CityRepository.SetAsync();
        return cities;
    }

    public async Task<City> GetCity(int cityId)
    {
        return await _unitOfWork.CityRepository.GetAsync(cityId);
    }

    public void UpdateCity(City city)
    {
        if (city == null) throw new ArgumentNullException(nameof(city));
        _unitOfWork.CityRepository.Update(city);
        _unitOfWork.SaveChanges();
    }
}
