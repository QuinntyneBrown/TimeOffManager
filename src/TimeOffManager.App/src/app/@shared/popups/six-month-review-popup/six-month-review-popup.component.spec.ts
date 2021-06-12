import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SixMonthReviewPopupComponent } from './six-month-review-popup.component';

describe('SixMonthReviewPopupComponent', () => {
  let component: SixMonthReviewPopupComponent;
  let fixture: ComponentFixture<SixMonthReviewPopupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SixMonthReviewPopupComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SixMonthReviewPopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
