import { Department } from "./department";

export class Employee {
  constructor(
    public id: number,
    public firstName: string,
    public lastName: string,
    public fullName: string,
    public birthDate: Date,
    public gender: string,
    public isCertified: boolean,
    public phone: string,
    public email: string,
    public departmentId: number,
    public department: Department) { }
}
