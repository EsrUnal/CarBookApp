using CarBookApp.Application.Interfaces;
using CarBookApp.Application.Mediator.Queries.CarPricingQueries;
using CarBookApp.Application.Mediator.Results.CarPricingResults;
using MediatR;

namespace CarBookApp.Application.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingsWithCarsQueryHandler : IRequestHandler<GetCarPricingsWithCarsQuery, List<GetCarPricingsWithCarsQueryResult>>
    {
        private readonly ICarPricingRepository _repository;

        public GetCarPricingsWithCarsQueryHandler(ICarPricingRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarPricingsWithCarsQueryResult>> Handle(GetCarPricingsWithCarsQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetCarPricingWithCarsAsync();
            return values.Select(x => new GetCarPricingsWithCarsQueryResult
            {
                Amount = x.Amount,
                CarID = x.CarID,
                CarPricingID = x.CarPricingID,
                PricingID = x.CarPricingID,
                BrandName = x.Car.Brand.Name,
                CoverImgUrl = x.Car.CoverImgUrl,
                Model = x.Car.Model,
                PricingName = x.Pricing.Name,
            }).ToList();
        }
    }
}
