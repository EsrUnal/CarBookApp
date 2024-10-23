using CarBookApp.Application.Interfaces;
using CarBookApp.Application.Mediator.Commands.TestimonialCommands;
using CarBookApp.Domain.Entities;
using MediatR;

namespace CarBookApp.Application.Mediator.Handlers.TestimonialHandlers
{
	public class RemoveTestimonialCommandHandler : IRequestHandler<RemoveTestimonialCommand>
	{
		private readonly IRepository<Testimonial> _repository;

		public RemoveTestimonialCommandHandler(IRepository<Testimonial> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveTestimonialCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			await _repository.DeleteAsync(value);
		}
	}
}
