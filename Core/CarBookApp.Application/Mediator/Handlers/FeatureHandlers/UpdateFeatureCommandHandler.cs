using CarBookApp.Application.Interfaces;
using CarBookApp.Application.Mediator.Commands.FeatureCommands;
using CarBookApp.Domain.Entities;
using MediatR;

namespace CarBookApp.Application.Mediator.Handlers.FeatureHandlers
{
    public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand>
    {
        private readonly IRepository<Feature> _repository;

        public UpdateFeatureCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        async Task IRequestHandler<UpdateFeatureCommand>.Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.FeatureID);
            value.FeatureID = request.FeatureID;
            value.Name = request.Name;
            await _repository.UpdateAsync(value);
        }
    }
}
