import { TestBed } from '@angular/core/testing';

import { UiContainerService } from './ui-container.service';

describe('UiContainerService', () => {
  let service: UiContainerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UiContainerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
