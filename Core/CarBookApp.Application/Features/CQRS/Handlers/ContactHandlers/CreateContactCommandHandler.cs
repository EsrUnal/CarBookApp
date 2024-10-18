using CarBookApp.Application.Features.CQRS.Commands.ContactCommands;
using CarBookApp.Application.Interfaces;
using CarBookApp.Domain.Entities;


namespace CarBookApp.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class CreateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public CreateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateContactCommand command)
        {
            await _repository.CreateAsync(new Contact
            {
                Subject = command.Subject,
                Email = command.Email,
                Message = command.Message,
                Name = command.Name,
                SendDate = command.SendDate,
            });
        }
    }
}
