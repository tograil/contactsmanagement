using AutoMapper;
using ContactsManagement.Domain.Contracts;
using MediatR;

namespace ContactsManagement.Server.Application.Contacts.Contacts;

public class ContactListHandler : IRequestHandler<ContactListRequest, IEnumerable<ContactListResponse>>
{
    private readonly IMapper _mapper;
    private readonly IContactsService _contactsService;

    public ContactListHandler(IMapper mapper, IContactsService contactsService)
    {
        _mapper = mapper;
        _contactsService = contactsService;
    }

    public Task<IEnumerable<ContactListResponse>> Handle(ContactListRequest request,
        CancellationToken cancellationToken)
    {
        return Task.FromResult(_mapper.Map<IEnumerable<ContactListResponse>>(_contactsService.GetContacts()));
    }
}