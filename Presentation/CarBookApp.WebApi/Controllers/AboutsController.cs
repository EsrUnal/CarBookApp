using CarBookApp.Application.Features.CQRS.Commands.AboutCommands;
using CarBookApp.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBookApp.Application.Features.CQRS.Queries.AboutQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CarBookApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly CreateAboutCommandHandler _creteCommandHandler;
        private readonly GetAboutByIdQueryHandler _getAboutByIdQueryHandler;
        private readonly GetAboutQueryHandler _getAboutQueryHandler;
        private readonly UpdateAboutCommandHandler _updateAboutByIdQueryHandler;
        private readonly RemoveAboutCommandHandler _removeAboutByIdQueryHandler;

        public AboutsController(CreateAboutCommandHandler creteCommandHandler, GetAboutByIdQueryHandler getAboutByIdQueryHandler, GetAboutQueryHandler getAboutQueryHandler, UpdateAboutCommandHandler updateAboutByIdQueryHandler, RemoveAboutCommandHandler removeAboutByIdQueryHandler)
        {
            _creteCommandHandler = creteCommandHandler;
            _getAboutByIdQueryHandler = getAboutByIdQueryHandler;
            _getAboutQueryHandler = getAboutQueryHandler;
            _updateAboutByIdQueryHandler = updateAboutByIdQueryHandler;
            _removeAboutByIdQueryHandler = removeAboutByIdQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var values = await _getAboutQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbout(int id)
        {
            var values = await _getAboutByIdQueryHandler.Handle(new GetAboutByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutCommand command)
        {
            await _creteCommandHandler.Handle(command);
            return Ok("Added the About Informations");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAbout(int id)
        {
            await _removeAboutByIdQueryHandler.Handle(new RemoveAboutCommand(id));
            return Ok("Deleted the About Informations");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand command)
        {
            await _updateAboutByIdQueryHandler.Handle(command);
            return Ok("Updated the About Information");
        }
    }
}
