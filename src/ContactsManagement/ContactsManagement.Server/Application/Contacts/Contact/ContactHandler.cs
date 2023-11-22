using AutoMapper;
using ContactsManagement.Domain.Contracts;
using ContactsManagement.Server.Application.Contacts.Contacts;
using MediatR;

namespace ContactsManagement.Server.Application.Contacts.Contact;

public class ContactHandler : IRequestHandler<ContactRequest, ContactResponse>
{
    private readonly IMapper _mapper;
    private readonly IContactsService _contactsService;

    public ContactHandler(IMapper mapper, IContactsService contactsService)
    {
        _mapper = mapper;
        _contactsService = contactsService;
    }

    public Task<ContactResponse> Handle(ContactRequest request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_mapper.Map<ContactResponse>(_contactsService.GetContact(request.Id)));
    }
}