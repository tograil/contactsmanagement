using ContactsManagement.Domain.Enums;
using ContactsManagement.Domain.Models;

namespace ContactsManagement.Domain.Contracts;

public interface IContactsService
{
    CreateContactStatus CreateContact(NewContact newContact);
    CreateContactStatus UpdateContact(Contact contact);
    CreateContactStatus DeleteContact(int contactId);
    Contact? GetContact(int contactId);
    IEnumerable<Contact> GetContacts();
}