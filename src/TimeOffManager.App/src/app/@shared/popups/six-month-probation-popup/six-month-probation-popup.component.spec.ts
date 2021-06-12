import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SixMonthProbationPopupComponent } from './six-month-probation-popup.component';

describe('SixMonthProbationPopupComponent', () => {
  let component: SixMonthProbationPopupComponent;
  let fixture: ComponentFixture<SixMonthProbationPopupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SixMonthProbationPopupComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SixMonthProbationPopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
