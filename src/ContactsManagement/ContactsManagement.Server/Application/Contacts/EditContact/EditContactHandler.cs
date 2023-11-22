using AutoMapper;
using ContactsManagement.Domain.Contracts;
using ContactsManagement.Server.Application.Contacts.NewContact;
using FluentValidation;
using MediatR;

namespace ContactsManagement.Server.Application.Contacts.EditContact;

public class EditContactHandler : IRequestHandler<EditContactRequest, EditContactResponse>
{
    private readonly IValidator<EditContactRequest> _validator;
    private readonly IMapper _mapper;
    private readonly IContactsService _contactsService;

    public EditContactHandler(IValidator<EditContactRequest> validator, IMapper mapper, IContactsService contactsService)
    {
        _validator = validator;
        _mapper = mapper;
        _contactsService = contactsService;
    }

    public Task<EditContactResponse> Handle(EditContactRequest request, CancellationToken cancellationToken)
    {
        _validator.ValidateAndThrow(request);

        return Task.FromResult(new EditContactResponse
        {
            Status = _contactsService.UpdateContact(_mapper.Map<Domain.Models.Contact>(request))
        });
    }
}