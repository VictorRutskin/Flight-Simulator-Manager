import { EventEmitter, Injectable } from '@angular/core';
import { Observable, Subject, Subscription } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UiContainerService {
  invokeFirstComponentFunction = new EventEmitter();    
  invokeRandomActionApiParkingCheckFunction = new EventEmitter(); // Update this line to correct property name
  subsVar: Subscription | undefined;    
    
  constructor() { }    

  WhenLandingEmit() { 
    return new Observable((observer) => {
      this.invokeFirstComponentFunction.emit();
      observer.complete();
    });
  }

  CheckParking() { 
    this.invokeRandomActionApiParkingCheckFunction.emit(); // Update this line to correct property name
  }
}
