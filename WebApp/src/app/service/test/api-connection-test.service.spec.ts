import { TestBed } from '@angular/core/testing';

import { ApiConnectionTestService } from './api-connection-test.service';

describe('ApiConnectionTestService', () => {
  let service: ApiConnectionTestService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ApiConnectionTestService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
