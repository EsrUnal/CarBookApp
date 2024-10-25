using CarBookApp.Application.Interfaces;
using CarBookApp.Application.Mediator.Commands.AuthorCommands;
using CarBookApp.Domain.Entities;
using MediatR;

namespace CarBookApp.Application.Mediator.Handlers.AuthorHandlers
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand>
    {
        private readonly IRepository<Author> _repository;

        public UpdateAuthorCommandHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.AuthorID);
            value.AuthorID = request.AuthorID;
            value.Description = request.Description;
            value.Name = request.Name;
            await _repository.UpdateAsync(value);
        }
    }
}
