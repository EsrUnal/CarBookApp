using CarBookApp.Application.Interfaces;
using CarBookApp.Application.Mediator.Commands.CarPricingCommands;
using CarBookApp.Domain.Entities;
using MediatR;

namespace CarBookApp.Application.Mediator.Handlers.CarPricingHandlers
{
    public class RemoveCarPricingCommandHandler:IRequestHandler<RemoveCarPricingCommand>
    {
        private readonly IRepository<CarPricing> _repository;

        public RemoveCarPricingCommandHandler(IRepository<CarPricing> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveCarPricingCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
