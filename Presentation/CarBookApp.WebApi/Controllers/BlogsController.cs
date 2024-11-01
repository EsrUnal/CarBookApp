using CarBookApp.Application.Mediator.Commands.BlogCommands;
using CarBookApp.Application.Mediator.Queries.BlogQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBookApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> BlogList()
        {
            var values = await _mediator.Send(new GetBlogQuery());
            return Ok(values);
        }

        [HttpGet("GetLast3BlogsWithAuthor")]
        public async Task<IActionResult> Last3BlogsList()
        {
            var values = await _mediator.Send(new GetLast3BlogsWithAuthorQuery());
            return Ok(values);
        }

        [HttpGet("GetBlogsWithAuthors")]
        public async Task<IActionResult> BlogsWithAuthorsList()
        {
            var values = await _mediator.Send(new GetBlogsWithAuthorsQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlog(int id)
        {
            var value = await _mediator.Send(new GetBlogByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Added The Blog Informations");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBlog(UpdateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Updated The Blog Informations");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBlog(int id)
        {
            await _mediator.Send(new RemoveBlogCommand(id));
            return Ok("Removed The Blog Informations");
        }
    }
}
