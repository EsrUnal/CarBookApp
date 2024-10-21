﻿using CarBookApp.Application.Interfaces;
using CarBookApp.Application.Mediator.Queries.ServiceQueries;
using CarBookApp.Application.Mediator.Results.ServiceResults;
using CarBookApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp.Application.Mediator.Handlers.ServiceHandlers
{
    public class GetServiceByIdQueryHandler:IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
    {
        private readonly IRepository<Service> _repository;

        public GetServiceByIdQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetServiceByIdQueryResult
            {
                ServiceID = value.ServiceID,
                Title = value.Title,
                Description = value.Description,
                IconUrl = value.IconUrl,
            };
        }
    }
}
