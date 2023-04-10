import { Component, OnInit } from '@angular/core';
import { AnimationService } from 'src/app/Services/Animation-service/animation.service';
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

  constructor(private animationService: AnimationService,private uiContainerService: UiContainerService) { } // Inject the service

  ngOnInit(): void {
    this.startLanding(); // Call the service method on component initialization
  }

  async startLanding(): Promise<void> {
    await this.animationService.landing(this); // Call the service method and pass the component instance
  }

  // checks from database which fields are occupied and paints them red
  CheckParked(): void{

  }

    // Call this method when landing event occurs
    onLanding() {
      this.uiContainerService.notifyLanding();
    }
  
  
}
