import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewTypesWashingComponent } from './new-types-washing.component';

describe('NewTypesWashingComponent', () => {
  let component: NewTypesWashingComponent;
  let fixture: ComponentFixture<NewTypesWashingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewTypesWashingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewTypesWashingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
