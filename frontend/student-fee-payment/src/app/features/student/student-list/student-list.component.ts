import { Component, OnInit } from '@angular/core';
import { StudentService } from '../services/student.service';
import { Student } from '../models/student.model';
import { BehaviorSubject, Observable, Subscription, tap } from 'rxjs';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css']
})
export class StudentListComponent implements OnInit {
  router: any;


  constructor(private studentService: StudentService){}

  deleteStudent?: Subscription;
  private students = new BehaviorSubject<Student[]>([]);
  students$ = this.students.asObservable();

  ngOnInit(): void {
    // this.students$ =  this.studentService.getAllStudents();
    this.students$ =  this.studentService.getAllStudents()
    .pipe(tap(response =>this.students.next(response)));
  }

  onDelete(id:any):void{
    console.log(id);
    if(id)
    {
      if(confirm("Delete Student?")){

      this.deleteStudent = this.studentService.deleteStudent(id).subscribe({
        next: (res) =>{
          const updatedStudents = this.students.getValue().filter(student => student.id !== id);
          this.students.next(updatedStudents);
          this.ngOnInit();
        }
      });
     }
    }
  }

}
