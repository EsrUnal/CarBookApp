using CarBookApp.Application.Features.CQRS.Commands.CategoryCommands;
using CarBookApp.Application.Interfaces;
using CarBookApp.Domain.Entities;

namespace CarBookApp.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;

        public UpdateCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCategoryCommand command)
        {
            var value = await _repository.GetByIdAsync(command.CategoryID);
            value.CategoryID = command.CategoryID;
            value.Name = command.Name;
            await _repository.UpdateAsync(value);
        }
    }
}
