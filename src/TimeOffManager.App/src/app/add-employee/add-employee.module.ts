import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddEmployeeRoutingModule } from './add-employee-routing.module';
import { AddEmployeeComponent } from './add-employee.component';
import { EmployeeHireDateModule } from '@shared/employee-hire-date/employee-hire-date.module';


@NgModule({
  declarations: [
    AddEmployeeComponent
  ],
  imports: [
    CommonModule,
    AddEmployeeRoutingModule,
    EmployeeHireDateModule
  ]
})
export class AddEmployeeModule { }
