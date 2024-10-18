using CarBookApp.Application.Features.CQRS.Queries.CarQueries;
using CarBookApp.Application.Features.CQRS.Results.CarResults;
using CarBookApp.Application.Interfaces;
using CarBookApp.Domain.Entities;

namespace CarBookApp.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            return new GetCarByIdQueryResult
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
            };
        }
    }
}
