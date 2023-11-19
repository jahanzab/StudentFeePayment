import { Component, OnDestroy, OnInit } from '@angular/core';
import { FeePaymentCreate } from '../models/fee-payment-create.model';
import { Observable, Subscription } from 'rxjs';
import { FeePaymentService } from '../services/fee-payment.service';
import { Router } from '@angular/router';
import { Student } from '../../student/models/student.model';
import { StudentService } from '../../student/services/student.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-fee-payment',
  templateUrl: './add-fee-payment.component.html',
  styleUrls: ['./add-fee-payment.component.css']
})
export class AddFeePaymentComponent implements OnInit, OnDestroy {

  feePayment: FeePaymentCreate;
  errors: any | null;
  private feePaymentSubscription?: Subscription
  students$?: Observable<Student[]>;
  
    constructor(private feePaymentService: FeePaymentService, private studentService: StudentService,
       private router: Router, private toastr: ToastrService){
      this.feePayment = {
        feeAmount : '',
        isPaid : false,
        paidDate: new Date(),
        feeYear : '',
        studentId : '',
        remarks : ''
      }
    }
  ngOnInit(): void {
    this.students$ = this.studentService.getAllStudents();
  }
  
  OnFormSubmit() {
    this.feePaymentSubscription = this.feePaymentService.addFeePayment(this.feePayment).subscribe({
      next: (res) =>{
        this.toastr.success('Fee Payment added successfully.');
        this.router.navigateByUrl('/fee-payments');
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
      this.feePaymentSubscription?.unsubscribe();
    }
  
  }
  
