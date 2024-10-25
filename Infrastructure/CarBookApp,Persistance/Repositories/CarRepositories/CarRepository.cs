using CarBookApp.Application.Interfaces;
using CarBookApp.Domain.Entities;
using CarBookApp_Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBookApp_Persistance.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookAppContext _appContext;

        public CarRepository(CarBookAppContext appContext)
        {
            _appContext = appContext;
        }

        public async Task<List<Car>> GetCarsListWithBrandsAsync()
        {
            var values = await _appContext.Cars.Include(x => x.Brand).ToListAsync();
            return values;
        }

        public async Task<List<Car>> GetLast5CarsWithBrandsAsync()
        {
            var values = await _appContext.Cars.Include(x => x.Brand).OrderByDescending(x => x.CarID).Take(5).ToListAsync();
            return values;
        }
    }
}
