using CarBookApp.Application.Interfaces;
using CarBookApp.Application.Mediator.Commands.FooterAddressCommands;
using CarBookApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp.Application.Mediator.Handlers.FooterAddressHandlers
{
    public class UpdateFooterAddressCommandHandler :IRequestHandler<UpdateFooterAddressCommand>
    {
        private readonly IRepository<FooterAddress> _repository;

        public UpdateFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.FooterAddressID);
            value.FooterAddressID = request.FooterAddressID;
            value.Address = request.Address;
            value.Phone = request.Phone;
            value.Email = request.Email;
            value.Description = request.Description;
            await _repository.UpdateAsync(value);
        }
    }
}
