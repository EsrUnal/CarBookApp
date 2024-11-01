using CarBookApp.Application.Interfaces;
using CarBookApp.Application.Mediator.Commands.CarPricingCommands;
using CarBookApp.Domain.Entities;
using MediatR;

namespace CarBookApp.Application.Mediator.Handlers.CarPricingHandlers
{
    public class UpdateCarPricingCommandHandler : IRequestHandler<UpdateCarPricingCommand>
    {
        private readonly IRepository<CarPricing> _repository;

        public UpdateCarPricingCommandHandler(IRepository<CarPricing> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarPricingCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.CarPricingID);
            value.Amount = request.Amount;
            value.CarPricingID = request.CarPricingID;
            value.CarID = request.CarPricingID;
            value.PricingID = request.PricingID;
            await _repository.UpdateAsync(value);
        }
    }
}
