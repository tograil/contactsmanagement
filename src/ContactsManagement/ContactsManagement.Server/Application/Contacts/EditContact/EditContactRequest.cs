using MediatR;

namespace ContactsManagement.Server.Application.Contacts.EditContact;

public class EditContactRequest : IRequest<EditContactResponse>
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
}