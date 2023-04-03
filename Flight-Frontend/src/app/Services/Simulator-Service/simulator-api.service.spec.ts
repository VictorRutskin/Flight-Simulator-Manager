import { TestBed } from '@angular/core/testing';

import { SimulatorApiService } from './simulator-api.service';

describe('SimulatorApiService', () => {
  let service: SimulatorApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SimulatorApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
