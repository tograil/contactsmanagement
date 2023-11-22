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

export enum CreateContactStatus {
    Success = 0,
    EmailAlreadyExists = 1,
    InvalidEmail = 2,
    ContactNotCreated = 3
}

export interface NewContactResponse {
    status: CreateContactStatus
}