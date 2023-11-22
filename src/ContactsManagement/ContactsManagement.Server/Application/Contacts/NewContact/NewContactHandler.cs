using AutoMapper;
using ContactsManagement.Domain.Contracts;
using FluentValidation;
using MediatR;

namespace ContactsManagement.Server.Application.Contacts.NewContact;

public class NewContactHandler : IRequestHandler<NewContactRequest, NewContactResponse>
{
    private readonly IValidator<NewContactRequest> _validator;
    private readonly IMapper _mapper;
    private readonly IContactsService _contactsService;

    public NewContactHandler(IValidator<NewContactRequest> validator,
        IMapper mapper, IContactsService contactsService)
    {
        _validator = validator;
        _mapper = mapper;
        _contactsService = contactsService;
    }

    public Task<NewContactResponse> Handle(NewContactRequest request, CancellationToken cancellationToken)
    {
        _validator.ValidateAndThrow(request);

        return Task.FromResult(new NewContactResponse
        {
            Status = _contactsService.CreateContact(_mapper.Map<Domain.Models.NewContact>(request))
        });
    }
}