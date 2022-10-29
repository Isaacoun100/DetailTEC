import { TestBed } from '@angular/core/testing';

import { TypesWashingService } from './types-washing.service';

describe('TypesWashingService', () => {
  let service: TypesWashingService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TypesWashingService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
