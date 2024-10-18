using CarBookApp.Application.Features.CQRS.Commands.CategoryCommands;
using CarBookApp.Application.Features.CQRS.Commands.ContactCommands;
using CarBookApp.Application.Interfaces;
using CarBookApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateContactCommand command)
        {
            var value = await _repository.GetByIdAsync(command.ContactID);
            value.Email = command.Email;
            value.SendDate = command.SendDate;
            value.Subject = command.Subject;
            value.Message = command.Message;
            value.Name = command.Name;
            value.ContactID = command.ContactID;
            await _repository.UpdateAsync(value);
        }
    }
}
