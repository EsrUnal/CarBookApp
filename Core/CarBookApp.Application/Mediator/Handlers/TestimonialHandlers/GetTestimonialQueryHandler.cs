using CarBookApp.Application.Interfaces;
using CarBookApp.Application.Mediator.Queries.TestimonialQueries;
using CarBookApp.Application.Mediator.Results.TestimonialResults;
using CarBookApp.Domain.Entities;
using MediatR;

namespace CarBookApp.Application.Mediator.Handlers.TestimonialHandlers
{
	public class GetTestimonialQueryHandler : IRequestHandler<GetTestimonialQuery, List<GetTestimonialQueryResult>>
	{
		private readonly IRepository<Testimonial> _repository;

		public GetTestimonialQueryHandler(IRepository<Testimonial> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetTestimonialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetTestimonialQueryResult
			{
				Comment = x.Comment,
				ImageUrl = x.ImageUrl,
				Name = x.Name,
				TestimonialID = x.TestimonialID,
				Title = x.Title,
			}).ToList();
		}
	}
}
