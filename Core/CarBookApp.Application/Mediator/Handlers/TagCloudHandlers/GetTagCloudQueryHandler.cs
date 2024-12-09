using CarBookApp.Application.Interfaces;
using CarBookApp.Application.Mediator.Queries.TagCloudQueries;
using CarBookApp.Application.Mediator.Results.TagCloudResults;
using CarBookApp.Domain.Entities;
using MediatR;

namespace CarBookApp.Application.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCloudQueryHandler : IRequestHandler<GetTagCloudQuery, List<GetTagCloudQueryResult>>
    {
        private readonly IRepository<TagCloud> _repository;

        public GetTagCloudQueryHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetTagCloudQueryResult>> Handle(GetTagCloudQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetTagCloudQueryResult
            {
                BlogID = x.BlogID,
                TagCloudID = x.TagCloudID,
                Title = x.Title,
            }).ToList();
        }
    }
}
