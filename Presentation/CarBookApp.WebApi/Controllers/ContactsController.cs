using CarBookApp.Application.Features.CQRS.Commands.CategoryCommands;
using CarBookApp.Application.Features.CQRS.Commands.ContactCommands;
using CarBookApp.Application.Features.CQRS.Handlers.ContactHandlers;
using CarBookApp.Application.Features.CQRS.Queries.ContactQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBookApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly GetContactQueryHandler _getContactQueryHandler;
        private readonly GetContactByIdQueryHandler _getContactByIdQueryHandler;
        private readonly CreateContactCommandHandler _createContactCommandHandler;
        private readonly UpdateContactCommandHandler _updateContactCommandHandler;
        private readonly RemoveContactCommandHandler _removeContactCommandHandler;

        public ContactsController(GetContactQueryHandler getContactQueryHandler, GetContactByIdQueryHandler getContactByIdQueryHandler, CreateContactCommandHandler createContactCommandHandler, UpdateContactCommandHandler updateContactCommandHandler, RemoveContactCommandHandler removeContactCommandHandler)
        {
            _getContactQueryHandler = getContactQueryHandler;
            _getContactByIdQueryHandler = getContactByIdQueryHandler;
            _createContactCommandHandler = createContactCommandHandler;
            _updateContactCommandHandler = updateContactCommandHandler;
            _removeContactCommandHandler = removeContactCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var values = await _getContactQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var value = await _getContactByIdQueryHandler.Handle(new GetContactByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateContactCommand command)
        {
            await _createContactCommandHandler.Handle(command);
            return Ok("Added The Contact Informations");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateContactCommand command)
        {
            await _updateContactCommandHandler.Handle(command);
            return Ok("Updated The Contact Information");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            await _removeContactCommandHandler.Handle(new RemoveContactCommand(id));
            return Ok("Removed The Contact Informations");
        }
    }
}
