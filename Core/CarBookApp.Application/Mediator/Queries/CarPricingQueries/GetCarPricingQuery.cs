using CarBookApp.Application.Mediator.Results.CarPricingResults;
using MediatR;

namespace CarBookApp.Application.Mediator.Queries.CarPricingQueries
{
    public class GetCarPricingQuery:IRequest<List<GetCarPricingQueryResult>>
    {
    }
}
