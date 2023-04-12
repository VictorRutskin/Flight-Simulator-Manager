import { SimulatorApiService } from './../../Services/Simulator-Service/simulator-api.service';
import { Component } from '@angular/core';
import { ConsoleService } from 'src/app/Services/Console-service/console.service';
import { UiContainerComponent } from '../ui-container/ui-container.component';
import { UiContainerService } from 'src/app/Services/ui-container-service/ui-container.service';

@Component({
  selector: 'controller',
  templateUrl: './controller.component.html',
  styleUrls: ['./controller.component.scss'],
})
export class ControllerComponent {
  private readonly StartSimulatorExtraUrl = 'api/flights/RandomAction';
  private simulationIntervalId: any;

  constructor(
    private simulatorApiService: SimulatorApiService,
    private consoleService: ConsoleService,
    private uiContainerService: UiContainerService // Add this line
  ) {}

  PerformLanding() {
    this.uiContainerService.onRandomActionApiCall();
  }

  startSimulation() {
    this.deleteAllPlanes(); // reseting data
    this.consoleService.log('Simulation started.');
    this.simulationIntervalId = setInterval(() => {
      this.RandomActionAPI();
    }, 5000); // interval of 5 seconds
  }

  stopSimulation() {
    clearInterval(this.simulationIntervalId);
    this.consoleService.log('Simulation stopped.');
  }

  getParkingPlanes() {
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
      async (response) => {
        this.consoleService.log(JSON.stringify(response));
        if (JSON.stringify(response).toString().includes('landed')) {
          this.PerformLanding();
        }
        // Add the following line to activate CheckParked() function
        this.uiContainerService.onRandomActionApiCall();
      },
      (error) => {
        this.consoleService.log('simulation error: ' + JSON.stringify(error));
      }
    );
  }

   // Delete All Planes
   deleteAllPlanes() {
    this.simulatorApiService.deleteAllPlanes().subscribe(
      (response: any) => {
      },
      (error: any) => {
      }
    );
  }

}
