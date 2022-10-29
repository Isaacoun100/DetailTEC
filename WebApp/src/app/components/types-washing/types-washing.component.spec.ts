import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TypesWashingComponent } from './types-washing.component';

describe('TypesWashingComponent', () => {
  let component: TypesWashingComponent;
  let fixture: ComponentFixture<TypesWashingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TypesWashingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TypesWashingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
