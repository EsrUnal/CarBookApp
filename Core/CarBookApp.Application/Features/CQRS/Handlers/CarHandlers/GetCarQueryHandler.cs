using CarBookApp.Application.Features.CQRS.Results.CarResults;
using CarBookApp.Application.Interfaces;
using CarBookApp.Domain.Entities;

namespace CarBookApp.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(value => new GetCarQueryResult
            {
                CarID = value.CarID,
                BrandID = value.BrandID,
                Transmission = value.Transmission,
                CoverImgUrl = value.CoverImgUrl,
                Fuel = value.Fuel,
                BigImageUrl = value.BigImageUrl,
                Km = value.Km,
                Luggage = value.Luggage,
                Model = value.Model,
                Seat = value.Seat
            }).ToList();
        }
    }
}
