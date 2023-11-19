import { Component, OnDestroy, OnInit } from '@angular/core';
import { StudentService } from '../services/student.service';
import { Student } from '../models/student.model';
import { BehaviorSubject, Observable, Subscription, tap } from 'rxjs';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css']
})
export class StudentListComponent implements OnInit, OnDestroy {

  constructor(private studentService: StudentService, private toastr: ToastrService){}

  deleteStudent?: Subscription;
  private students = new BehaviorSubject<Student[]>([]);
  students$ = this.students.asObservable();

  ngOnInit(): void {
    this.students$ =  this.studentService.getAllStudents()
    .pipe(tap(response =>this.students.next(response)));
  }

  onDelete(id:any):void{
    console.log(id);
    if(id)
    {
      if(confirm("Are you sure? This will delete the student payment records also!!")){

      this.deleteStudent = this.studentService.deleteStudent(id).subscribe({
        next: (res) =>{
          const updatedStudents = this.students.getValue().filter(student => student.id !== id);
          this.students.next(updatedStudents);
          this.ngOnInit();
          this.toastr.success('Student Deleted successfully.');
        },
        error: (res) =>{
          console.log(res);
          this.toastr.error(res);
        }
      });
     }
    }
  }

  ngOnDestroy(): void {
    this.deleteStudent?.unsubscribe();
    this.students.unsubscribe();
  }

}
