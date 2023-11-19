import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FeePaymentService } from '../services/fee-payment.service';
import { Subscription } from 'rxjs';
import { FeePaymentDetails } from '../models/fee-payment-details.model';
import { FeePaymentUpdate } from '../models/fee-payment-update.model copy';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-fee-payment-details',
  templateUrl: './fee-payment-details.component.html',
  styleUrls: ['./fee-payment-details.component.css']
})
export class FeePaymentDetailsComponent implements OnInit, OnDestroy {

  
  constructor(private feePaymentService: FeePaymentService, private route: ActivatedRoute,
    private router: Router, private toastr: ToastrService){}

  id:string | null = null;
  paramsSubscription?: Subscription;
  feePayment?:FeePaymentDetails;
  editFeePayment?: Subscription;
  errors: any | null;

  ngOnInit(): void {
    this.paramsSubscription = this.route.paramMap.subscribe({
      next: (params) => {
         this.id = params.get('id');

         if(this.id){
            this.feePaymentService.getFeePaymentById(this.id).subscribe({
              next: (res) =>{
                this.feePayment = res;
              }
            });
         }
      },
      error: (res) =>{
        
      }
    });
  }

  OnFormSubmit() {
    if(this.feePayment && this.id){
    let updateFeePaymentRequest : FeePaymentUpdate = {
      remarks: this.feePayment.remarks
    }

    if(this.id)
    {
      this.editFeePayment = this.feePaymentService.updateFeePaymentById(this.id, updateFeePaymentRequest).subscribe({
        next: (res) =>{
          this.router.navigateByUrl('/fee-payments')
          this.toastr.success('Updated successfully!')
        },
        error: (res) =>{
          if(res.error.errors){
            this.errors = res.error.errors;
            this.toastr.error('Error(s).');
          }
          else if(res.error){
            this.toastr.error(res.error)
            this.errors = res.error;
            this.toastr.error('Error(s).');
          }
        }
      });
    }
   }
  }

  ngOnDestroy(): void {
    this.paramsSubscription?.unsubscribe();
    this.editFeePayment?.unsubscribe();
  }

}
