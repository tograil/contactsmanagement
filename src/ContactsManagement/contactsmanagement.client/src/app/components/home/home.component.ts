import { Component, OnInit, QueryList, TemplateRef, ViewChildren } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Observable } from 'rxjs';
import { NgbdSortableHeader, SortEvent } from 'src/app/directives/sorting.directive';
import { Contact, ContactStatus } from 'src/app/dto/contact';
import { ContactsSortService } from 'src/app/services/contacts-sort.service';
import { ContactsService } from 'src/app/services/contacts.service';
import { FeedbackService } from 'src/app/services/feedback.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  closeResult = '';
  contacts$: Observable<Contact[]>;
	total$: Observable<number>;

  @ViewChildren(NgbdSortableHeader) headers: QueryList<NgbdSortableHeader> = new QueryList<NgbdSortableHeader>();

  constructor(private contactService: ContactsService,
     private modalService: NgbModal,
     private feedbackService: FeedbackService,
     public contactsSortService: ContactsSortService) {
      this.contacts$ = contactsSortService.contacts$;
		  this.total$ = contactsSortService.total$;
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
    this.contactsSortService.reload();
  }

  onSort({ column, direction }: SortEvent) {
    this.headers.forEach((header) => {
			if (header.sortable !== column) {
				header.direction = '';
			}
		});

		this.contactsSortService.sortColumn = column;
		this.contactsSortService.sortDirection = direction;
	}

  ngOnInit(): void {
    this.loadContacts();
  }
}
