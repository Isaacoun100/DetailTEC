import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewTypesWashingComponent } from './view-types-washing.component';

describe('ViewTypesWashingComponent', () => {
  let component: ViewTypesWashingComponent;
  let fixture: ComponentFixture<ViewTypesWashingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewTypesWashingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewTypesWashingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
