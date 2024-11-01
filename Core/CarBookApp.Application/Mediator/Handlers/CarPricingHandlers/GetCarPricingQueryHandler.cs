using CarBookApp.Application.Interfaces;
using CarBookApp.Application.Mediator.Queries.CarPricingQueries;
using CarBookApp.Application.Mediator.Results.CarPricingResults;
using CarBookApp.Domain.Entities;
using MediatR;

namespace CarBookApp.Application.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingQueryHandler : IRequestHandler<GetCarPricingQuery, List<GetCarPricingQueryResult>>
    {
        private readonly IRepository<CarPricing> _repository;

        public GetCarPricingQueryHandler(IRepository<CarPricing> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarPricingQueryResult>> Handle(GetCarPricingQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetCarPricingQueryResult
            {
                Amount = x.Amount,
                CarID = x.CarID,
                CarPricingID = x.CarPricingID,
                PricingID = x.PricingID,
            }).ToList();
        }
    }
}
