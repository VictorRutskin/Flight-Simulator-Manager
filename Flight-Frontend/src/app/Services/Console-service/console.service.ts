import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ConsoleService {
  
  consoleMessages$ = new Subject<string>();

  constructor() {}

  log(message: string) {
    this.consoleMessages$.next(message);
  }
}
