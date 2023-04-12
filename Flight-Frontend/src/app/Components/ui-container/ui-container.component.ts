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
  applyStyle: number = 0; // 

  constructor(private uiContainerService: UiContainerService) { } // Inject the service

  ngOnInit(): void {
    this.startLanding(); // Call the service method on component initialization
  }

  async startLanding(): Promise<void> {
    while (this.applyStyle < 5) {
      await new Promise(resolve => setTimeout(resolve, 500));
      this.applyStyle += 1;
    }
    this.applyStyle = 0;
    this.onLanding(); 
  }

  // checks from database which fields are occupied and paints them red
  CheckParked(): void{

  }

    // Call this method when landing event occurs
    onLanding() {
      this.uiContainerService.notifyLanding();
    }
  
  
}
