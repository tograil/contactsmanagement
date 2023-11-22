using ContactsManagement.Domain.Enums;
using ContactsManagement.Domain.Models;

namespace ContactsManagement.Domain.Contracts;

public interface IContactsService
{
    CreateContactStatus CreateContact(NewContact newContact);
}