import { Injectable } from "@angular/core";
import { Department } from "../models/department";
import { Employee } from "../models/employee";
import { HttpClient, HttpParams } from "@angular/common/http";
import { Observable } from "rxjs/Rx";

@Injectable({ providedIn: "root" })
export class DataService {
  readonly employeeUrl = "api/employees";
  readonly departmentUrl = "api/departments";

  constructor(private readonly http: HttpClient) { }

  getEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>(this.employeeUrl);
  }

  getEmployee(id: number): Observable<Employee> {
    return this.http.get<Employee>(this.employeeUrl + "/" + id);
  }

  addEmployee(employee: Employee): Observable<Employee> {
    return this.http.post<Employee>(this.employeeUrl, employee);
  }

  updateEmployee(employee: Employee): Observable<void> {
    const urlParams = new HttpParams().set("id", employee.id.toString());
    return this.http.put<void>(this.employeeUrl, employee, { params: urlParams });
  }

  deleteEmployee(id: number): Observable<Employee> {
    return this.http.delete<Employee>(this.employeeUrl + "/" + id);
  }

  getDepartments(): Observable<Department[]> {
    return this.http.get<Department[]>(this.departmentUrl);
  }
}
