using ContactsManagement.Domain.Enums;

namespace ContactsManagement.Server.Application.Contacts.NewContact;

public class NewContactResponse
{
    public CreateContactStatus Status { get; set; }
}