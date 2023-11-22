import { Component, OnInit } from '@angular/core';
import { Contact } from 'src/app/dto/contact';
import { ContactsService } from 'src/app/services/contacts.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  private contacts: Contact[] = [];

  constructor(private contactService: ContactsService) {

  }

  ngOnInit(): void {
    this.contactService.getContacts()
      .subscribe(cont => {
        this.contacts = cont;
      });
  }
}
