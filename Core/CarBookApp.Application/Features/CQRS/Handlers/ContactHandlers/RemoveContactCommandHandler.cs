using CarBookApp.Application.Features.CQRS.Commands.ContactCommands;
using CarBookApp.Application.Interfaces;
using CarBookApp.Domain.Entities;

namespace CarBookApp.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class RemoveContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public RemoveContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveContactCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
