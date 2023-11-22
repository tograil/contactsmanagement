using AutoMapper;
using ContactsManagement.Server.Application.Contacts.Contact;
using ContactsManagement.Server.Application.Contacts.Contacts;
using ContactsManagement.Server.Application.Contacts.DeleteContact;
using ContactsManagement.Server.Application.Contacts.EditContact;
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
        public async Task<ContactResponse> Get(int id)
        {
            return await _mediator.Send(new ContactRequest { Id = id });
        }

        [HttpPost]
        public async Task<NewContactResponse> Post([FromBody] NewContactModel value)
        {
            return await _mediator.Send(_mapper.Map<NewContactRequest>(value));
        }

        [HttpPut("{id}")]
        public async Task<EditContactResponse> Put(int id, [FromBody] ContactModel value)
        {
            if (id != value.Id)
            {
                throw new ArgumentException("Id mismatch");
            }

            return await _mediator.Send(_mapper.Map<EditContactRequest>(value));
        }

        [HttpDelete("{id}")]
        public async Task<DeleteContactResponse> Delete(int id)
        {
            return await _mediator.Send(new DeleteContactRequest { Id = id });
        }
    }
}
