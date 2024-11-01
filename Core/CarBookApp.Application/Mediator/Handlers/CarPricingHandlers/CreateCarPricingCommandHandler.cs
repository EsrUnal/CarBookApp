using CarBookApp.Application.Interfaces;
using CarBookApp.Application.Mediator.Commands.CarPricingCommands;
using CarBookApp.Domain.Entities;
using MediatR;

namespace CarBookApp.Application.Mediator.Handlers.CarPricingHandlers
{
    public class CreateCarPricingCommandHandler:IRequestHandler<CreateCarPricingCommand>
    {
        private readonly IRepository<CarPricing> _repository;

        public CreateCarPricingCommandHandler(IRepository<CarPricing> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCarPricingCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new CarPricing
            {
                Amount = request.Amount,
                CarID = request.CarID,
                CarPricingID = request.CarID,
                PricingID = request.CarID,
            });
        }
    }
}
