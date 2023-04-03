import { SimulatorApiService } from './../../Services/Simulator-Service/simulator-api.service';
import { Component } from '@angular/core';
import { Subject } from 'rxjs';
import { ConsoleService } from 'src/app/Services/Console-service/console.service';

@Component({
selector: 'controller',
templateUrl: './controller.component.html',
styleUrls: ['./controller.component.scss']
})
export class ControllerComponent {
private readonly StartSimulatorExtraUrl = 'api/flights/RandomAction';
private logSubject = new Subject<string>();
private simulationIntervalId: any;

constructor(
private simulatorApiService: SimulatorApiService,
private consoleService: ConsoleService
) {}

startSimulation() {
this.consoleService.log("Simulation started.");
this.simulationIntervalId = setInterval(() => {
this.RandomActionAPI();
}, 3000); // interval of 3 seconds
}

stopSimulation() {
  clearInterval(this.simulationIntervalId);
  this.consoleService.log("Simulation stopped.");
}

getParkingPlanes(){
  this.simulatorApiService.getFlights().subscribe(
  (response) => {
  this.consoleService.log(JSON.stringify(response));
  },
  (error) => {
  this.consoleService.log('simulation error: ' + JSON.stringify(error));
  }
  );
  }

RandomActionAPI() {
this.simulatorApiService.RandomAction().subscribe(
(response) => {
this.consoleService.log(JSON.stringify(response));
},
(error) => {
this.consoleService.log('simulation error: ' + JSON.stringify(error));
}
);
}

}