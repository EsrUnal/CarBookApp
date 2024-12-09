using CarBookApp.Application.Interfaces;
using CarBookApp.Application.Mediator.Queries.TagCloudQueries;
using CarBookApp.Application.Mediator.Results.TagCloudResults;
using MediatR;

namespace CarBookApp.Application.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCloudByBlogIdQueryHandler : IRequestHandler<GetTagCloudByBlogIdQuery, List<GetTagCloudByBlogIdQueryResult>>
    {
        private readonly ITagCloudRepository _repository;

        public GetTagCloudByBlogIdQueryHandler(ITagCloudRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTagCloudByBlogIdQueryResult>> Handle(GetTagCloudByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetTagCloudByBlogId(request.Id);
            return values.Select(x => new GetTagCloudByBlogIdQueryResult
            {
                BlogID = x.BlogID,
                TagCloudID = x.TagCloudID,
                Title = x.Title,
            }).ToList();
        }
    }
}
