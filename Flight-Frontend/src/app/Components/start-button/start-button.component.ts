import { environment } from '../../Environments/Environment';
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Subject } from 'rxjs';

@Component({
  selector: 'start-button',
  templateUrl: './start-button.component.html',
  styleUrls: ['./start-button.component.scss'],
})
export class StartSimulationButtonComponent {
  private readonly StartSimulatorExtraUrl = 'api/flights/RandomAction';
  private logSubject = new Subject<string>();

  constructor(private http: HttpClient) {}

  startSimulation() {
    this.http
      .post(environment.apiUrl + this.StartSimulatorExtraUrl, null)
      .subscribe(
        () => {
          console.log('Simulation started.');
          this.logSubject.next('Simulation started.');
        },
        (error) => {
          console.error(error);
          this.logSubject.next('Error starting simulation: ' + error);
        }
      );
  }

  getLogObservable() {
    return this.logSubject.asObservable();
  }
}
