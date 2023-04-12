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

  async RandomActionAPI() {
    this.simulatorApiService.RandomAction().subscribe(
      async (response) => {
        this.consoleService.log(JSON.stringify(response));
        if (JSON.stringify(response).toString().includes("landed")) {
          // await this.animationService.landing(this); // Pass this reference
        }
      },
      (error) => {
        this.consoleService.log('simulation error: ' + JSON.stringify(error));
      }
    );
  }
  

  
  
  
  

}
