import { Component, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { StudentService } from '../services/student.service';
import { StudentCreateUpdate } from '../models/student-create-update.model';
import { Subscription } from 'rxjs';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-student',
  templateUrl: './add-student.component.html',
  styleUrls: ['./add-student.component.css']
})
export class AddStudentComponent implements OnDestroy {

student: StudentCreateUpdate;
errors: any | null;
private studentSubscription?: Subscription

  constructor(private studentService: StudentService, private router: Router, private toastr: ToastrService){
    this.student = {
      firstName : '',
      lastName : '',
      email : '',
      phone : '',
      address : '',
      dob : new Date(),
      grade : '',
      studentNumber: '',
    }
  }

OnFormSubmit() {
  this.studentSubscription = this.studentService.addStudent(this.student).subscribe({
    next: (res) =>{
      this.toastr.success('Student added successfully.');
      this.router.navigateByUrl('/students');
    },
    error: (res)=>{
      if(res.error.errors){
        this.errors = res.error.errors;
        this.toastr.error('Error(s).');
      }
      else if(res.error){
        this.errors = res.error;
        this.toastr.error('Error(s).');
      }
    },
    complete: ()=>{
    }
  });
  }

  ngOnDestroy(): void {
    this.studentSubscription?.unsubscribe();
  }

}
