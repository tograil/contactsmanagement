using MediatR;

namespace ContactsManagement.Server.Application.Contacts.DeleteContact;

public class DeleteContactRequest : IRequest<DeleteContactResponse>
{
    public int Id { get; set; }
}