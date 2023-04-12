import { SimulatorApiService } from './../../Services/Simulator-Service/simulator-api.service';
import { Component, OnInit } from '@angular/core';
import { UiContainerService } from 'src/app/Services/ui-container-service/ui-container.service';

@Component({
  selector: 'ui-container',
  templateUrl: './ui-container.component.html',
  styleUrls: ['./ui-container.component.scss']
})
export class UiContainerComponent {
  UI_Cube_Border_Occupied: string | undefined = '#ce0202';
  UI_Cube_Border_Free: string | undefined = '#15bf15';
  applyStyle: number = 0; 
  ParkingPlanes:number = 0;

  constructor(private uiContainerService: UiContainerService, private simulatorApiService:SimulatorApiService) { } // Inject the service

  ngOnInit(): void {
    if (this.uiContainerService.subsVar == undefined) {
      this.uiContainerService.subsVar = this.uiContainerService.invokeFirstComponentFunction.subscribe(
        (name: string) => {
          this.startLanding();
        }
      );
    }

    // Add the following lines to subscribe to the randomActionApiCallSubject
    this.uiContainerService.invokeRandomActionApiFunction.subscribe(() => {
      this.CheckParked();
    });
  }  

  async startLanding(): Promise<void> {
    while (this.applyStyle < 5) {
      await new Promise(resolve => setTimeout(resolve, 500));
      this.applyStyle += 1;
    }
    this.applyStyle = 0;
  }

  // checks from database which fields are occupied and paints them red
  CheckParked(): void {
    this.simulatorApiService.getAmountOfParked().subscribe(
      count => {
        this.ParkingPlanes = count;
      },
      error => {
        console.error('Failed to get amount of parked planes:', error);
      }
    )
  }


  
  
}
