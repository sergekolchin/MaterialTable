import { PipeTransform, Pipe } from "@angular/core";

@Pipe({ name: "gender" })
export class GenderPipe implements PipeTransform {
  transform(value, args) {
    return value === 0 ? "Male" : "Female";
  }
}
