using CarBookApp.Application.Interfaces;
using CarBookApp.Application.Mediator.Commands.LocationCommands;
using CarBookApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp.Application.Mediator.Handlers.LocationHandlers
{
    public class UpdateLocationCommandHandler:IRequestHandler<UpdateLocationCommand>
    {
        private readonly IRepository<Location> _repository;

        public UpdateLocationCommandHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.LocationID);
            value.LocationID = request.LocationID;
            value.Name = request.Name;
            await _repository.UpdateAsync(value);
        }
    }
}
