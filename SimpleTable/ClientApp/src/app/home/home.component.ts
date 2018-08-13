import { Component, OnInit, ViewChild, Inject } from "@angular/core";
import { MatPaginator, MatSort, MatTableDataSource, MatDialog, MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { DataService } from "../services/dataService";
import { Employee } from "../models/employee";
import { Department } from "../models/department";
import { Gender } from "../models/gender";
import { DatePipe } from "@angular/common";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  providers: [DatePipe]
})
export class HomeComponent implements OnInit {
  displayedColumns: string[] = ["id", "fullName", "birthDate", "gender", "isCertified", "phone", "email", "department"];

  dataSource: MatTableDataSource<Employee>;
  users: Employee[];
  datePipe: DatePipe;

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild((MatSort) as any) sort: MatSort;

  constructor(public dialog: MatDialog, private readonly dataService: DataService, datePipe: DatePipe) {
    this.datePipe = datePipe;
  }

  ngOnInit(): void {
    this.dataService.getEmployees().subscribe(result => {
      this.users = result;
      this.dataSource = new MatTableDataSource(this.users);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    }, error => {
      console.log("getEmployees() error: ", error);
    });
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(AddEmployeeDialog, {
      width: "450px",
      data: {}
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.dataService.addEmployee(result).subscribe(employee => {
          this.users.push(employee);
          //refresh table
          this.dataSource.data = this.users;
        },
          error => console.log("addEmployee() error", error));
      }
    });
  }
}

@Component({
  selector: "add-employee-dialog",
  templateUrl: "./addEmployee.dialog.html",
})
export class AddEmployeeDialog implements OnInit {
  formGroup: FormGroup;
  departments: Department[];
  genders: Gender[] = [{ id: 0, name: "Male" }, { id: 1, name: "Female" }];

  constructor(public dialogRef: MatDialogRef<AddEmployeeDialog>, @Inject(MAT_DIALOG_DATA) public data: Employee, fb: FormBuilder,
    private readonly dataService: DataService) {
    this.formGroup = fb.group({
      id: fb.control(!data.id ? 0 : data.id),
      firstName: fb.control("", [Validators.required]),
      lastName: fb.control("", [Validators.required]),
      birthDate: fb.control("", [Validators.required]),
      phone: fb.control("", [Validators.required]),
      email: fb.control("", [Validators.required, Validators.email]),
      genderId: fb.control("", [Validators.required]),
      departmentId: fb.control("", [Validators.required]),
      isCertified: fb.control(!data.isCertified ? false : data.isCertified)
    });
  }

  get genderId() { return this.formGroup.get("genderId"); }
  get email() { return this.formGroup.get("email"); }

  ngOnInit(): void {
    this.dataService.getDepartments().subscribe(result => {
      this.departments = result;
    }, error => {
      console.log("getDepartments() error: ", error);
    });
  }

  submit(form) {
    this.dialogRef.close(form.value);
  }

  onCancelClick(): void {
    this.dialogRef.close();
  }
}
