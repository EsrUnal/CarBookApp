using CarBookApp.Application.Interfaces;
using CarBookApp.Application.Mediator.Commands.BlogCommands;
using CarBookApp.Domain.Entities;
using MediatR;

namespace CarBookApp.Application.Mediator.Handlers.BlogHandlers
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public UpdateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.BlogID);
            value.Title = request.Title;
            value.Description = request.Description;
            value.CreatedDate = request.CreatedDate;
            value.CategoryID = request.CategoryID;
            value.AuthorID = request.AuthorID;
            value.CoverImageUrl = request.CoverImageUrl;
            value.BlogID = request.BlogID;
            await _repository.UpdateAsync(value);
        }
    }
}
