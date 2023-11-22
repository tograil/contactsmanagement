using AutoMapper;
using ContactsManagement.Domain.Models;
using ContactsManagement.Server.Application.Contacts.Contacts;
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
        CreateMap<ContactListResponse, ContactModel>();
    }
}