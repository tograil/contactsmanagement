namespace ContactsManagement.Domain.Enums;

public enum CreateContactStatus
{
    Success,
    EmailAlreadyExists,
    InvalidEmail,
    ContactNotCreated
}