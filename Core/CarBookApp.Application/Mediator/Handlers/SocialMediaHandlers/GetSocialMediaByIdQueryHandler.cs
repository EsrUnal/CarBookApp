using CarBookApp.Application.Interfaces;
using CarBookApp.Application.Mediator.Queries.SocialMediaQueries;
using CarBookApp.Application.Mediator.Results.Social_Media_Results;
using CarBookApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp.Application.Mediator.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaByIdQueryHandler:IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
    {
        private readonly IRepository<SocialMedia> _repository;

        public GetSocialMediaByIdQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetSocialMediaByIdQueryResult
            {
                SocialMediaID = value.SocialMediaID,
                Name = value.Name,
                Url = value.Url,
                Icon = value.Icon,
            };
        }
    }
}
