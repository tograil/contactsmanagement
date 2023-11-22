import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { Contact, NewContact, ContactResponse } from '../dto/contact';

@Injectable({
  providedIn: 'root'
})
export class ContactsService {

  constructor(private http: HttpClient) { }

  public getContacts() : Observable<Contact[]> {
    return this.http.get<Contact[]>('/api/contacts');
  }

  public getContact(id: number) : Observable<Contact> {
    return this.http.get<Contact>(`/api/contacts/${id}`);
  }

  public deleteContact(id: number) : Observable<ContactResponse> {
    return this.http.delete<ContactResponse>(`/api/contacts/${id}`);
  }

  public saveContact(contact: NewContact) : Observable<ContactResponse> {
    return this.http.post<ContactResponse>('/api/contacts', contact);
  }

  public updateContact(id: number, contact: Contact) : Observable<ContactResponse> {
    return this.http.put<ContactResponse>(`/api/contacts/${id}`, contact);
  }
}
