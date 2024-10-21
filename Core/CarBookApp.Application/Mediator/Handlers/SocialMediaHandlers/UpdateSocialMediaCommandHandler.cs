using CarBookApp.Application.Interfaces;
using CarBookApp.Application.Mediator.Commands.SocialMediaCommands;
using CarBookApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp.Application.Mediator.Handlers.SocialMediaHandlers
{
    public class UpdateSocialMediaCommandHandler:IRequestHandler<UpdateSocialMediaCommand>
    {
        private readonly IRepository<SocialMedia> _repository;

        public UpdateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.SocialMediaID);
            value.SocialMediaID = request.SocialMediaID;
            value.Name = request.Name;
            value.Url = request.Url;
            value.Icon = request.Icon;  
            await _repository.UpdateAsync(value);
        }
    }
}
