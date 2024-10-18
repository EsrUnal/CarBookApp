using CarBookApp.Domain.Entities;

namespace CarBookApp.Application.Interfaces
{
    public interface ICarRepository
    {
        Task<List<Car>> GetCarsListWithBrandsAsync();
    }
}
