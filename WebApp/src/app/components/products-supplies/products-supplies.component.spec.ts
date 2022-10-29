import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductsSuppliesComponent } from './products-supplies.component';

describe('ProductsSuppliesComponent', () => {
  let component: ProductsSuppliesComponent;
  let fixture: ComponentFixture<ProductsSuppliesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductsSuppliesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductsSuppliesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
