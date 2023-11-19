import { Component, OnDestroy, OnInit } from '@angular/core';
import { FeePaymentService } from '../services/fee-payment.service';
import { FeePayment } from '../models/fee-payment.model';
import { BehaviorSubject, Observable } from 'rxjs';

@Component({
  selector: 'app-fee-payment-list',
  templateUrl: './fee-payment-list.component.html',
  styleUrls: ['./fee-payment-list.component.css']
})
export class FeePaymentListComponent implements OnInit,OnDestroy {

  constructor(private feePaymentService: FeePaymentService){}

  fee_payments$?:Observable<FeePayment[]>;

  ngOnInit(): void {
    this.fee_payments$ =  this.feePaymentService.getAllFeePayments();
  }

  ngOnDestroy(): void {
   
  }

}
