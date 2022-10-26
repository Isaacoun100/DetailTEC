import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditTypesWashingComponent } from './edit-types-washing.component';

describe('EditTypesWashingComponent', () => {
  let component: EditTypesWashingComponent;
  let fixture: ComponentFixture<EditTypesWashingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditTypesWashingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditTypesWashingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
