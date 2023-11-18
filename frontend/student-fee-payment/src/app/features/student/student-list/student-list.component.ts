import { Component, OnInit } from '@angular/core';
import { StudentService } from '../services/student.service';
import { Student } from '../models/student.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css']
})
export class StudentListComponent implements OnInit {


  constructor(private studentService: StudentService){}

  students$?:Observable<Student[]>;

  ngOnInit(): void {
    this.studentService.getAllStudents().subscribe({
      next: (res)=>{
        console.log(res);
      }
    });
   // console.log(this.students$);
  }

}
