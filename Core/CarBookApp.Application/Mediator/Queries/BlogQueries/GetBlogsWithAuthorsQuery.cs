using CarBookApp.Application.Mediator.Results.BlogResults;
using MediatR;

namespace CarBookApp.Application.Mediator.Queries.BlogQueries
{
    public class GetBlogsWithAuthorsQuery:IRequest<List<GetBlogsWithAuthorsQueryResult>>
    {
    }
}
