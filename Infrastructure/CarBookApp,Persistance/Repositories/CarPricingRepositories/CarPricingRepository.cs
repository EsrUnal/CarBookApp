using CarBookApp.Application.Interfaces;
using CarBookApp.Domain.Entities;
using CarBookApp_Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBookApp_Persistance.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookAppContext _appContext;

        public CarPricingRepository(CarBookAppContext appContext)
        {
            _appContext = appContext;
        }

        public async Task<List<CarPricing>> GetCarPricingWithCarsAsync()
        {
            var values = await _appContext.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(x => x.Pricing).ToListAsync();
            return values;
        }
    }
}
