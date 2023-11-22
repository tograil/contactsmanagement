using ContactsManagement.Domain.Contracts;
using MediatR;

namespace ContactsManagement.Server.Application.Contacts.DeleteContact;

public class DeleteContactHandler : IRequestHandler<DeleteContactRequest, DeleteContactResponse>
{
    private readonly IContactsService _contactsService;

    public DeleteContactHandler(IContactsService contactsService)
    {
        _contactsService = contactsService;
    }

    public Task<DeleteContactResponse> Handle(DeleteContactRequest request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new DeleteContactResponse
        {
            Status = _contactsService.DeleteContact(request.Id)
        });
    }
}