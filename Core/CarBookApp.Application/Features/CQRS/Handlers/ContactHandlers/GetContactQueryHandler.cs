using CarBookApp.Application.Features.CQRS.Results.ContactResults;
using CarBookApp.Application.Interfaces;
using CarBookApp.Domain.Entities;

namespace CarBookApp.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetContactQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetContactQueryResult
            {
                ContactID = x.ContactID,
                Email = x.Email,
                Message = x.Message,
                Name = x.Name,
                SendDate = x.SendDate,
                Subject = x.Subject,
            }).ToList();
        }
    }
}
