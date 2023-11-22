import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { Contact, NewContact, NewContactResponse } from '../dto/contact';

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

  public saveContact(contact: NewContact) : Observable<NewContactResponse> {
    return this.http.post<NewContactResponse>('/api/contacts', contact);
  }

  public updateContact(id: number, contact: Contact) : Observable<NewContactResponse> {
    return this.http.put<NewContactResponse>(`/api/contacts/${id}`, contact);
  }
}
