using CarBookApp.Application.Interfaces;
using CarBookApp.Application.Mediator.Queries.PricingQueries;
using CarBookApp.Application.Mediator.Results.PricingResults;
using CarBookApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp.Application.Mediator.Handlers.PricingHandlers
{
    public class GetPricingByIdQueryHandler:IRequestHandler<GetPricingByIdQuery, GetPricingByIdQueryResult>
    {
        private readonly IRepository<Pricing> _repository;

        public GetPricingByIdQueryHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task<GetPricingByIdQueryResult> Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetPricingByIdQueryResult
            {
                Name = value.Name,
                PricingID = value.PricingID,
            };
        }
    }
}
