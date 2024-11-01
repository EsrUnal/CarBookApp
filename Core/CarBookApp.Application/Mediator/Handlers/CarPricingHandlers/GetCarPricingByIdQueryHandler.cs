using CarBookApp.Application.Interfaces;
using CarBookApp.Application.Mediator.Queries.CarPricingQueries;
using CarBookApp.Application.Mediator.Results.CarPricingResults;
using CarBookApp.Domain.Entities;
using MediatR;

namespace CarBookApp.Application.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingByIdQueryHandler : IRequestHandler<GetCarPricingByIdQuery, GetCarPricingByIdQueryResult>
    {
        private readonly IRepository<CarPricing> _repository;

        public GetCarPricingByIdQueryHandler(IRepository<CarPricing> repository)
        {
            _repository = repository;
        }

        public async Task<GetCarPricingByIdQueryResult> Handle(GetCarPricingByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetCarPricingByIdQueryResult
            {
                Amount = value.Amount,
                CarID = value.CarID,
                CarPricingID = value.CarPricingID,
                PricingID = value.PricingID,
            };
        }
    }
}
