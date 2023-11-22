using MediatR;

namespace ContactsManagement.Server.Application.Contacts.Contacts;

public class ContactListRequest : IRequest<IEnumerable<ContactListResponse>>
{
    
}