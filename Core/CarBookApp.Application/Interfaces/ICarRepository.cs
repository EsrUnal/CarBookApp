using CarBookApp.Domain.Entities;

namespace CarBookApp.Application.Interfaces
{
    public interface ICarRepository
    {
        Task<List<Car>> GetCarsListWithBrandsAsync();
        Task<List<Car>> GetLast5CarsWithBrandsAsync();
    }
}
