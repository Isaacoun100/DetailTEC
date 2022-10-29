import { TestBed } from '@angular/core/testing';

import { ProductsSuppliesService } from './products-supplies.service';

describe('ProductsSuppliesService', () => {
  let service: ProductsSuppliesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProductsSuppliesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
