﻿using ContactsManagement.Domain.Contracts;
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

    public CreateContactStatus UpdateContact(Contact contact)
    {
        throw new NotImplementedException();
    }

    public CreateContactStatus DeleteContact(int contactId)
    {
        throw new NotImplementedException();
    }

    public Contact? GetContact(int contactId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Contact> GetContacts()
    {
        return _dbContext.Set<Contact>().ToList();
    }
}