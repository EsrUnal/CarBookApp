using CarBookApp.Application.Mediator.Results.BlogResults;
using MediatR;

namespace CarBookApp.Application.Mediator.Queries.BlogQueries
{
    public class GetLast3BlogsWithAuthorQuery:IRequest<List<GetLast3BlogsWithAuthorQueryResult>>
    {
    }
}
