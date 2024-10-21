using CarBookApp.Application.Interfaces;
using CarBookApp.Application.Mediator.Queries.FooterAddressQueries;
using CarBookApp.Application.Mediator.Results.FooterAddressResults;
using CarBookApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp.Application.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressQueryHandler:IRequestHandler<GetFooterAddressQuery, List<GetFooterAddressQueryResult>>
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterAddressQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetFooterAddressQueryResult 
            { 
                FooterAddressID = x.FooterAddressID,
                Address = x.Address,
                Description = x.Description,
                Email = x.Email,
                Phone = x.Phone,
            }).ToList();
        }
    }
}
