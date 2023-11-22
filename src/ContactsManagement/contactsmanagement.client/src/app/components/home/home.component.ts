import { Component, OnInit, TemplateRef } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Contact, ContactStatus } from 'src/app/dto/contact';
import { ContactsService } from 'src/app/services/contacts.service';
import { FeedbackService } from 'src/app/services/feedback.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public contacts: Contact[] = [];
  closeResult = '';

  constructor(private contactService: ContactsService, private modalService: NgbModal, private feedbackService: FeedbackService) {
    
  }

  confirmDelete(id: number, content: TemplateRef<any>) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then(
			(result) => {
				this.contactService.deleteContact(id)
          .subscribe(response => {
            if (response.status == ContactStatus.Success) {
              this.feedbackService.showFeedback("Delete");
              this.loadContacts();
            }
          })
			},
			(reason) => {
				this.closeResult = `Dismissed ${reason}`;
			},
		);
  }

  loadContacts() {
    this.contactService.getContacts()
      .subscribe(cont => {
        this.contacts = cont;
      });
  }

  ngOnInit(): void {
    this.loadContacts();
  }
}
