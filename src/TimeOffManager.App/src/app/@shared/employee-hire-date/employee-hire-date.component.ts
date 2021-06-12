import { Component, ElementRef, forwardRef, Input, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { AbstractControl, ControlValueAccessor, FormArray, FormControl, FormGroup, NG_VALIDATORS, NG_VALUE_ACCESSOR, ValidationErrors, Validator, Validators } from '@angular/forms';
import { takeUntil, tap } from 'rxjs/operators';
import { fromEvent, Subject } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';
import { SixMonthProbationPopupComponent } from '@shared/popups/six-month-probation-popup/six-month-probation-popup.component';

@Component({
  selector: 'app-employee-hire-date',
  templateUrl: './employee-hire-date.component.html',
  styleUrls: ['./employee-hire-date.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => EmployeeHireDateComponent),
      multi: true
    },
    {
      provide: NG_VALIDATORS,
      useExisting: forwardRef(() => EmployeeHireDateComponent),
      multi: true
    }
  ]
})
export class EmployeeHireDateComponent implements ControlValueAccessor,  Validator, OnDestroy  {
  private readonly _destroyed$: Subject<void> = new Subject();

  public form = new FormGroup({
    hireDate: new FormControl(null, [Validators.required]),
    sixMonthReviewRequired: new FormControl(null, []),
  });

  constructor(
    private readonly _elementRef: ElementRef,
    private readonly _dialog: MatDialog
  ) { }

  validate(control: AbstractControl): ValidationErrors | null {
      return this.form.valid ? null
      : Object.keys(this.form.controls).reduce(
          (accumulatedErrors, formControlName) => {
            const errors: ValidationErrors = { ...accumulatedErrors };

            const controlErrors = this.form.controls[formControlName].errors;

            if (controlErrors) {
              errors[formControlName] = controlErrors;
            }

            return errors;
          },
          {}
        );
  }

  viewProbation() {
    this._dialog.open<SixMonthProbationPopupComponent>(SixMonthProbationPopupComponent)
    .afterClosed()
    .subscribe();
  }

  writeValue(obj: any): void {
    if(obj == null) {
      this.form.reset();
    }
    else {
      this.form.patchValue(obj, { emitEvent: false });
    }
  }

  registerOnChange(fn: any): void {
    this.form.valueChanges.subscribe(fn);
  }

  registerOnTouched(fn: any): void {
    this._elementRef.nativeElement
      .querySelectorAll("*")
      .forEach((element: HTMLElement) => {
        fromEvent(element, "focus")
          .pipe(
            takeUntil(this._destroyed$),
            tap(x => fn())
          )
          .subscribe();
      });
  }

  setDisabledState?(isDisabled: boolean): void {
    isDisabled ? this.form.disable() : this.form.enable();
  }

  public ngOnDestroy() {
    this._destroyed$.next();
    this._destroyed$.complete();
  }
}
