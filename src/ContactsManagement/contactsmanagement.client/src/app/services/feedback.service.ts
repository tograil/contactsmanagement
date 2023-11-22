import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FeedbackService {

  private feedbackSubject:Subject<string> = new Subject<string>();
  public feedback$ = this.feedbackSubject.asObservable();

  constructor() { }

  public showFeedback(func: string): void {
    this.feedbackSubject.next(func);
  }
}
