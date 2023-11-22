import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Contact, ContactStatus } from 'src/app/dto/contact';
import { ContactsService } from 'src/app/services/contacts.service';

@Component({
  selector: 'app-edit-contact',
  templateUrl: './edit-contact.component.html',
  styleUrls: ['./edit-contact.component.css']
})
export class EditContactComponent implements OnInit {
  contactForm : FormGroup = new FormGroup({
    "id": new FormControl(0),
    "firstName": new FormControl("", Validators.required),
    "lastName": new FormControl("", Validators.required),
    "email": new FormControl("", [ Validators.required, Validators.email])
  });
  
  constructor(private contactsService: ContactsService,
    private route: ActivatedRoute,
    private router: Router) {
  }

  submit() {
    let contact: Contact = this.contactForm.value;

    this.contactsService.updateContact(contact.id, contact)
    .subscribe(newContactResponse => {
      if (newContactResponse.status == ContactStatus.EmailAlreadyExists) {
        alert('Email already exists');
      }
      else if (newContactResponse.status == ContactStatus.Success) {
        this.router.navigate(["/"]);
      }
    })
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe(value => {
      this.contactsService.getContact(Number(value.get('id')))
        .subscribe(contact => {
          this.contactForm.setValue(contact);
        })
    });  
  }
}
