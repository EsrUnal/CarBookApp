using CarBookApp.Application.Interfaces;
using CarBookApp.Application.Mediator.Queries.LocationQueries;
using CarBookApp.Application.Mediator.Results.LocationResults;
using CarBookApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp.Application.Mediator.Handlers.LocationHandlers
{
    public class GetLocationByIdQueryHandler:IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
    {
        private readonly IRepository<Location> _repository;

        public GetLocationByIdQueryHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetLocationByIdQueryResult
            {
                LocationID = value.LocationID,
                Name = value.Name,
            };
        }
    }
}
