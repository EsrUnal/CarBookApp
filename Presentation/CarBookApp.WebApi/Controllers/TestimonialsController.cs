using CarBookApp.Application.Mediator.Commands.TestimonialCommands;
using CarBookApp.Application.Mediator.Queries.TestimonialQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBookApp.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestimonialsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public TestimonialsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> TestimonialList()
		{
			var values = await _mediator.Send(new GetTestimonialQuery());
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetTestimonial(int id)
		{
			var value = await _mediator.Send(new GetTestimonialByIdQuery(id));
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CretaeTestimonial(CreateTestimonialCommand command)
		{
			await _mediator.Send(command);
			return Ok("Added The Testimonial Informations");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialCommand command)
		{
			await _mediator.Send(command);
			return Ok("Updated The Testimonial Informations");
		}

		[HttpDelete]
		public async Task<IActionResult> RemoveTestimonial(int id)
		{
			await _mediator.Send(new RemoveTestimonialCommand(id));
			return Ok("Removed The Testimonial Informations");
		}
	}
}
