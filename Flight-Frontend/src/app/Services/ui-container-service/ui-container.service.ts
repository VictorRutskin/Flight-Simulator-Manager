import { EventEmitter, Injectable } from '@angular/core';
import { Subject, Subscription } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UiContainerService {
  invokeFirstComponentFunction = new EventEmitter();    
  invokeRandomActionApiFunction = new EventEmitter(); // Update this line to correct property name
  subsVar: Subscription | undefined;    
    
  constructor() { }    

  onRandomActionApiCall() { 
    this.invokeRandomActionApiFunction.emit(); // Update this line to correct property name
  }
}
