export interface Contact
{
    id: number,
    firstName: string,
    lastName: string,
    email: string
}

export interface NewContact {
    firstName: string,
    lastName: string,
    email: string
}

export enum ContactStatus {
    Success = 0,
    EmailAlreadyExists = 1,
    InvalidEmail = 2,
    ContactNotCreated = 3,
    ContactNotFound = 4
}

export interface ContactResponse {
    status: ContactStatus
}