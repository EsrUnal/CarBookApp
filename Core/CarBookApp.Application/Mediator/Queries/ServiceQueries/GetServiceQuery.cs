using CarBookApp.Application.Mediator.Results.ServiceResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp.Application.Mediator.Queries.ServiceQueries
{
    public class GetServiceQuery: IRequest<List<GetServiceQueryResult>>
    {
    }
}
