import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeeHireDateComponent } from './employee-hire-date.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '@shared/material.module';
import { SixMonthProbationPopupModule } from '@shared/popups/six-month-probation-popup/six-month-probation-popup.module';



@NgModule({
  declarations: [
    EmployeeHireDateComponent
  ],
  exports: [
    EmployeeHireDateComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    MaterialModule,
    SixMonthProbationPopupModule
  ]
})
export class EmployeeHireDateModule { }
