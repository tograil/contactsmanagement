using MediatR;

namespace ContactsManagement.Server.Application.Contacts.Contact;

public class ContactRequest : IRequest<ContactResponse>
{
    public int Id { get; set; }
}