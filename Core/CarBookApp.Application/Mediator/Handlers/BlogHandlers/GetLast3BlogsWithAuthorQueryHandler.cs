
using CarBookApp.Application.Interfaces;
using CarBookApp.Application.Mediator.Queries.BlogQueries;
using CarBookApp.Application.Mediator.Results.BlogResults;
using MediatR;

namespace CarBookApp.Application.Mediator.Handlers.BlogHandlers
{
    public class GetLast3BlogsWithAuthorQueryHandler : IRequestHandler<GetLast3BlogsWithAuthorQuery, List<GetLast3BlogsWithAuthorQueryResult>>
    {
        public IBlogRepository _repository;

        public GetLast3BlogsWithAuthorQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLast3BlogsWithAuthorQueryResult>> Handle(GetLast3BlogsWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetLast3BlogsWithAuthor();
            return values.Select(x => new GetLast3BlogsWithAuthorQueryResult
            {
                BlogID = x.BlogID,
                AuthorID = x.AuthorID,
                AuthorName = x.Author.Name,
                CreatedDate = x.CreatedDate,
                CategoryID = x.CategoryID,
                CoverImageUrl = x.CoverImageUrl,
                Description = x.Description,
                Title = x.Title,
            }).ToList();
        }
    }
}
