import { environment } from './../Environments/Environment';
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'start-button',
  templateUrl: './start-button.component.html',
  styleUrls: ['./start-button.component.scss'],
})
export class StartSimulationButtonComponent {
  private readonly StartSimulatorExtraUrl = 'api/flights/RandomAction';

  constructor(private http: HttpClient) {}

  startSimulation() {
    this.http
      .post(environment.apiUrl + this.StartSimulatorExtraUrl, null)
      .subscribe(
        () => console.log('Simulation started.'),
        (error) => console.error(error)
      );
  }
}
