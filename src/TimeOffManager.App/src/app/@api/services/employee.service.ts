import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { Employee } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService implements IPagableService<Employee> {

  uniqueIdentifierName: string = "employeeId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<Employee>> {
    return this._client.get<EntityPage<Employee>>(`${this._baseUrl}api/employee/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<Employee[]> {
    return this._client.get<{ employees: Employee[] }>(`${this._baseUrl}api/employee`)
      .pipe(
        map(x => x.employees)
      );
  }

  public getById(options: { employeeId: string }): Observable<Employee> {
    return this._client.get<{ employee: Employee }>(`${this._baseUrl}api/employee/${options.employeeId}`)
      .pipe(
        map(x => x.employee)
      );
  }

  public remove(options: { employee: Employee }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/employee/${options.employee.employeeId}`);
  }

  public create(options: { employee: Employee }): Observable<{ employee: Employee }> {
    return this._client.post<{ employee: Employee }>(`${this._baseUrl}api/employee`, { employee: options.employee });
  }
  
  public update(options: { employee: Employee }): Observable<{ employee: Employee }> {
    return this._client.put<{ employee: Employee }>(`${this._baseUrl}api/employee`, { employee: options.employee });
  }
}
