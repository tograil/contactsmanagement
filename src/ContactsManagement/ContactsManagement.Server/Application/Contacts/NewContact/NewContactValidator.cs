using FluentValidation;

namespace ContactsManagement.Server.Application.Contacts.NewContact;

public class NewContactValidator 
    : AbstractValidator<NewContactRequest>
{
    public NewContactValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
    }
}