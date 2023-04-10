import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UiContainerService {
  private landingSubject = new Subject<void>();
  landing$ = this.landingSubject.asObservable();

  notifyLanding() {
    this.landingSubject.next();
  }
}
