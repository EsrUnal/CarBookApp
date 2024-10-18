using CarBookApp.Application.Features.CQRS.Commands.CarCommands;
using CarBookApp.Application.Interfaces;
using CarBookApp.Domain.Entities;

namespace CarBookApp.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarCommand command)
        {
            var value = await _repository.GetByIdAsync(command.CarID);
            value.CarID = command.CarID;
            value.BrandID = command.BrandID;
            value.Model = command.Model;
            value.CoverImgUrl = command.CoverImgUrl;
            value.Km = command.Km;
            value.Transmission = command.Transmission;
            value.Seat = command.Seat;
            value.Luggage = command.Luggage;
            value.Fuel = command.Fuel;
            value.BigImageUrl = command.BigImageUrl;
            await _repository.UpdateAsync(value);
                
        }
    }
}
