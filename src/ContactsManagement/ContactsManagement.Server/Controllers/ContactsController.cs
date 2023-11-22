using AutoMapper;
using ContactsManagement.Domain.Models;
using ContactsManagement.Server.Application.Contacts.Contacts;
using ContactsManagement.Server.Application.Contacts.NewContact;
using ContactsManagement.Server.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ContactsManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;


        public ContactsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ContactModel>> Get()
        {
            return _mapper.Map<IEnumerable<ContactModel>>(await _mediator.Send(new ContactListRequest()));
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public async Task<NewContactResponse> Post([FromBody] NewContactModel value)
        {
            return await _mediator.Send(_mapper.Map<NewContactRequest>(value));
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
