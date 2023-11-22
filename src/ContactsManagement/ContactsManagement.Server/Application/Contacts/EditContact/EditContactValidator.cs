using FluentValidation;

namespace ContactsManagement.Server.Application.Contacts.EditContact;

public class EditContactValidator 
    : AbstractValidator<EditContactRequest>
{
    public EditContactValidator()
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