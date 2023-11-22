using AutoMapper;
using ContactsManagement.Domain.Models;
using ContactsManagement.Server.Application.Contacts.Contact;
using ContactsManagement.Server.Application.Contacts.Contacts;
using ContactsManagement.Server.Application.Contacts.EditContact;
using ContactsManagement.Server.Application.Contacts.NewContact;
using ContactsManagement.Server.Models;

namespace ContactsManagement.Server.Maps;

public class ContactsProfile : Profile
{
    public ContactsProfile()
    {
        CreateMap<NewContactModel, NewContactRequest>();
        CreateMap<NewContactRequest, NewContact>();
        CreateMap<Contact, ContactListResponse>();
        CreateMap<Contact, ContactResponse>();
        CreateMap<ContactModel, EditContactRequest>();
        CreateMap<EditContactRequest, Contact>();
        CreateMap<ContactListResponse, ContactModel>();
    }
}