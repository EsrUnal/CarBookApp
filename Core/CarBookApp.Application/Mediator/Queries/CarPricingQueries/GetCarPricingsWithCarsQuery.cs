using CarBookApp.Application.Mediator.Results.CarPricingResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp.Application.Mediator.Queries.CarPricingQueries
{
    public class GetCarPricingsWithCarsQuery : IRequest<List<GetCarPricingsWithCarsQueryResult>>
    {
    }
}
