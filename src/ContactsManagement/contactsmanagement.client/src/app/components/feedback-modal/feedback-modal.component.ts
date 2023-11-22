import { Component, Input, Output, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-feedback-modal',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './feedback-modal.component.html',
  styleUrl: './feedback-modal.component.css'
})
export class FeedbackModalComponent {
  activeModal = inject(NgbActiveModal);
  @Input() name: string = '';

  @Output() feedback: string = '';
}
