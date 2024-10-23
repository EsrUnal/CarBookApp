using CarBookApp.Application.Features.CQRS.Queries.AboutQueries;
using CarBookApp.Application.Features.CQRS.Results.AboutResults;
using CarBookApp.Application.Interfaces;
using CarBookApp.Application.Mediator.Queries.TestimonialQueries;
using CarBookApp.Application.Mediator.Results.TestimonialResults;
using CarBookApp.Domain.Entities;
using MediatR;

namespace CarBookApp.Application.Mediator.Handlers.TestimonialHandlers
{
	public class GetTestimonialByIdQueryHandler:IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
	{
		private readonly IRepository<Testimonial> _repository;

		public GetTestimonialByIdQueryHandler(IRepository<Testimonial> repository)
		{
			_repository = repository;
		}

		public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			return new GetTestimonialByIdQueryResult{
				Comment = value.Comment,
				ImageUrl = value.ImageUrl,
				Name = value.Name,
				TestimonialID = value.TestimonialID,
				Title = value.Title,
			};
		}
	}
}
