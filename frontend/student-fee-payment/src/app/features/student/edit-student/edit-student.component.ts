import { Component, OnDestroy, OnInit } from '@angular/core';
import { StudentService } from '../services/student.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Student } from '../models/student.model';
import { StudentDetails } from '../models/student-details.model';
import { StudentCreateUpdate } from '../models/student-create-update.model';

@Component({
  selector: 'app-edit-student',
  templateUrl: './edit-student.component.html',
  styles: [
  ]
})
export class EditStudentComponent implements OnInit, OnDestroy {
onValueChange($event: any) {
throw new Error('Method not implemented.');
}

  constructor(private studentService: StudentService, private route: ActivatedRoute,
    private router: Router){}

  id:string | null = null;
  paramsSubscription?: Subscription;
  student?:StudentDetails;
  editStudent?: Subscription;
  errors: any | null;

  ngOnInit(): void {
    this.paramsSubscription = this.route.paramMap.subscribe({
      next: (params) => {
         this.id = params.get('id');

         if(this.id){
            this.studentService.getStudentById(this.id).subscribe({
              next: (res) =>{
                console.log(res);
                this.student = res;
              }
            });
         }
      },
      error: (res) =>{
        
      }
    });
  }

  OnFormSubmit() {
    if(this.student && this.id){
    let updateStudentRequest : StudentCreateUpdate = {
      firstName : this.student?.firstName,
      lastName :this.student?.lastName,
      email : this.student?.email,
      phone : this.student?.phone,
      address : this.student?.address,
      dob : this.student?.dob,
      grade : this.student?.grade,
      studentNumber: this.student?.studentNumber
    }

    if(this.id)
    {
      this.editStudent = this.studentService.updateStudentById(this.id, updateStudentRequest).subscribe({
        next: (res) =>{
          this.router.navigateByUrl('/students')
        },
        error: (res) =>{
          this.errors = res.error.errors;
        }
      });
    }
   }
  }

  ngOnDestroy(): void {
    this.paramsSubscription?.unsubscribe();
    this.editStudent?.unsubscribe();
  }

}
