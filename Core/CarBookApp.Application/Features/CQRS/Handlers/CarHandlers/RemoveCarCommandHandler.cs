﻿using CarBookApp.Application.Features.CQRS.Commands.CarCommands;
using CarBookApp.Application.Interfaces;
using CarBookApp.Domain.Entities;

namespace CarBookApp.Application.Features.CQRS.Handlers.CarHandlers
{
    public class RemoveCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public RemoveCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveCarCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
