using ContactsManagement.Domain.Contracts;
using ContactsManagement.Domain.Enums;
using ContactsManagement.Domain.Models;
using ContactsManagement.Infrastructure.Context;

namespace ContactsManagement.Infrastructure.Services;

public class ContactsService : IContactsService
{
    private readonly ContactsManagementContext _dbContext;

    public ContactsService(ContactsManagementContext dbContext)
    {
        _dbContext = dbContext;
    }

    public CreateContactStatus CreateContact(NewContact newContact)
    {
        throw new NotImplementedException();
    }
}