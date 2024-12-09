using CarBookApp.Application.Interfaces;
using CarBookApp.Application.Mediator.Commands.TagCloudCommands;
using CarBookApp.Domain.Entities;
using MediatR;

namespace CarBookApp.Application.Mediator.Handlers.TagCloudHandlers
{
    public class UpdateTagCloudCommandHandler : IRequestHandler<UpdateTagCloudCommand>
    {
        private readonly IRepository<TagCloud> _repository;

        public UpdateTagCloudCommandHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateTagCloudCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.TagCloudID);
            value.BlogID = request.TagCloudID;
            value.TagCloudID = request.TagCloudID;
            value.Title = request.Title;
            await _repository.UpdateAsync(value);
        }
    }
}
