import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ConsoleService {
  
  consoleMessages$ = new Subject<string>();

  constructor() {}

  log(message: string, CutMessage:boolean) {
    if (CutMessage == true)
    {
    // Remove first 12 letters
    const truncatedMessage = message.substring(12);
    // Remove last 2 letters
    const finalMessage = truncatedMessage.slice(0, -2);
    this.consoleMessages$.next(finalMessage);
    }
    else
    {
      this.consoleMessages$.next(message);
    }
}
}
