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

    public ContactStatus CreateContact(NewContact newContact)
    {
        try
        {
            var contact = new Contact
            {
                FirstName = newContact.FirstName,
                LastName = newContact.LastName,
                Email = newContact.Email
            };

            if (_dbContext.Set<Contact>().Any(c => c.Email == contact.Email))
                return ContactStatus.EmailAlreadyExists;

            _dbContext.Set<Contact>().Add(contact);

            return _dbContext.SaveChanges() > 0
                ? ContactStatus.Success
                : ContactStatus.ContactNotCreated;
        }
        catch (Exception)
        {
            return ContactStatus.ContactNotCreated;
        }
    }

    public ContactStatus UpdateContact(Contact contact)
    {
        try
        {
            if (_dbContext.Set<Contact>().Any(c => c.Email == contact.Email && c.Id != contact.Id))
                return ContactStatus.EmailAlreadyExists;

            _dbContext.Set<Contact>().Update(contact);

            return _dbContext.SaveChanges() > 0
                ? ContactStatus.Success
                : ContactStatus.ContactNotCreated;
        }
        catch (Exception)
        {
            return ContactStatus.ContactNotCreated;
        }
    }

    public ContactStatus DeleteContact(int contactId)
    {
        var contact = _dbContext.Set<Contact>().FirstOrDefault(x => x.Id == contactId);

        if (contact == null)
            return ContactStatus.ContactNotFound;

        _dbContext.Set<Contact>().Remove(contact);

        return _dbContext.SaveChanges() > 0
            ? ContactStatus.Success
            : ContactStatus.ContactNotFound;
    }

    public Contact? GetContact(int contactId)
    {
        return _dbContext.Set<Contact>()
            .FirstOrDefault(x => x.Id == contactId);
    }

    public IEnumerable<Contact> GetContacts()
    {
        return _dbContext.Set<Contact>().ToList();
    }
}