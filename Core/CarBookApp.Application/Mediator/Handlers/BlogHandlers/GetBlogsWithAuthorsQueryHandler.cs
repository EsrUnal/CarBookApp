using CarBookApp.Application.Interfaces;
using CarBookApp.Application.Mediator.Queries.BlogQueries;
using CarBookApp.Application.Mediator.Results.BlogResults;
using MediatR;

namespace CarBookApp.Application.Mediator.Handlers.BlogHandlers
{
    public class GetBlogsWithAuthorsQueryHandler : IRequestHandler<GetBlogsWithAuthorsQuery, List<GetBlogsWithAuthorsQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetBlogsWithAuthorsQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogsWithAuthorsQueryResult>> Handle(GetBlogsWithAuthorsQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetBlogsWithAuthors();
            return values.Select(x => new GetBlogsWithAuthorsQueryResult
            {
                AuthorID = x.AuthorID,
                BlogID = x.BlogID,
                CategoryID = x.CategoryID,
                CoverImageUrl = x.CoverImageUrl,
                CreatedDate = x.CreatedDate,
                Description = x.Description,
                Title = x.Title,
                AuthorName = x.Author.Name
            }).ToList();
        }
    }
}
