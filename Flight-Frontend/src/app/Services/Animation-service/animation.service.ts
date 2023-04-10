import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable()
export class AnimationService {
  async landing(component: any): Promise<void> {
    while(component.applyStyle < 5) {
      await new Promise(resolve => setTimeout(resolve, 500));
      component.applyStyle += 1;
    }
    component.applyStyle = 0;
  }
}