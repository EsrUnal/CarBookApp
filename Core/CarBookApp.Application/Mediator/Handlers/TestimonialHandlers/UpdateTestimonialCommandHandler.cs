using CarBookApp.Application.Interfaces;
using CarBookApp.Application.Mediator.Commands.TestimonialCommands;
using CarBookApp.Domain.Entities;
using MediatR;

namespace CarBookApp.Application.Mediator.Handlers.TestimonialHandlers
{
	public class UpdateTestimonialCommandHandler:IRequestHandler<UpdateTestimonialCommand>
	{
		private readonly IRepository<Testimonial> _repository;

		public UpdateTestimonialCommandHandler(IRepository<Testimonial> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.TestimonialID);
			value.TestimonialID = request.TestimonialID;
			value.Comment = request.Comment;
			value.Name = request.Name;
			value.Title = request.Title;
			value.ImageUrl = request.ImageUrl;
			await _repository.UpdateAsync(value);
		}
	}
}
