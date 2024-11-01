using CarBookApp.Application.Mediator.Results.CarPricingResults;
using MediatR;

namespace CarBookApp.Application.Mediator.Queries.CarPricingQueries
{
    public class GetCarPricingByIdQuery:IRequest<GetCarPricingByIdQueryResult>
    {
        public int Id { get; set; }

        public GetCarPricingByIdQuery(int id)
        {
            Id = id;
        }
    }
}
