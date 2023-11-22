import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CreateContactStatus, NewContact } from 'src/app/dto/contact';
import { ContactsService } from 'src/app/services/contacts.service';

@Component({
  selector: 'app-new-contact',
  templateUrl: './new-contact.component.html',
  styleUrls: ['./new-contact.component.css']
})
export class NewContactComponent {
  contactForm : FormGroup = new FormGroup({
    "firstName": new FormControl("", Validators.required),
    "lastName": new FormControl("", Validators.required),
    "email": new FormControl("", [ Validators.required, Validators.email])
  });

  constructor(private router: Router, private contactsService: ContactsService) {
  }

  submit() {
    let newContact: NewContact = this.contactForm.value;
    
    this.contactsService.saveContact(newContact)
      .subscribe(newContactResponse => {
        if (newContactResponse.status == CreateContactStatus.EmailAlreadyExists) {
          alert('Email already exists');
        }
        else if (newContactResponse.status == CreateContactStatus.Success) {
          this.router.navigate(["/"]);
        }
      })
  }
}
