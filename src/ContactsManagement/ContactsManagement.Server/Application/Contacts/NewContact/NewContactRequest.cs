using MediatR;

namespace ContactsManagement.Server.Application.Contacts.NewContact;

public class NewContactRequest : IRequest<NewContactResponse>
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
}