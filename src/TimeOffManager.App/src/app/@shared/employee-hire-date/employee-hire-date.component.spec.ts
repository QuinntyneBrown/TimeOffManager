import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeHireDateComponent } from './employee-hire-date.component';

describe('EmployeeHireDateComponent', () => {
  let component: EmployeeHireDateComponent;
  let fixture: ComponentFixture<EmployeeHireDateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmployeeHireDateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeHireDateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
