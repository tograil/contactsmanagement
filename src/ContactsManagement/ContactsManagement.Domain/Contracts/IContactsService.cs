using ContactsManagement.Domain.Enums;
using ContactsManagement.Domain.Models;

namespace ContactsManagement.Domain.Contracts;

public interface IContactsService
{
    ContactStatus CreateContact(NewContact newContact);
    ContactStatus UpdateContact(Contact contact);
    ContactStatus DeleteContact(int contactId);
    Contact? GetContact(int contactId);
    IEnumerable<Contact> GetContacts();
}