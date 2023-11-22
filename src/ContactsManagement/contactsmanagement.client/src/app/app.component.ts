import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FeedbackService } from './services/feedback.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FeedbackModalComponent } from './components/feedback-modal/feedback-modal.component';
import { ContactsSortService } from './services/contacts-sort.service';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  public forecasts: WeatherForecast[] = [];

  constructor(private feedbackService: FeedbackService,
    private modalService: NgbModal,
    public contactsSortService: ContactsSortService) {}

  ngOnInit() {
    this.feedbackService.feedback$.subscribe(data => {
      const modalRef = this.modalService.open(FeedbackModalComponent);
		  modalRef.componentInstance.name = data;

      modalRef.result.then(res => {
        
      })
    })
  }

  title = 'contactsmanagement.client';
}
