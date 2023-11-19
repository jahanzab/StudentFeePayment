import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { FeePayment } from '../models/fee-payment.model';
import { Observable } from 'rxjs';
import { FeePaymentDetails } from '../models/fee-payment-details.model';
import { FeePaymentUpdate } from '../models/fee-payment-update.model copy';
import { FeePaymentCreate } from '../models/fee-payment-create.model';

@Injectable({
  providedIn: 'root'
})
export class FeePaymentService {

  constructor(private http: HttpClient) { }

  private apiBaseUrl:string = environment.apiBaseUrl;
  private apiUrl = `${this.apiBaseUrl}/feePayments`

  getAllFeePayments(): Observable<FeePayment[]> { 
    return this.http.get<FeePayment[]>(this.apiUrl);
  }

  getFeePaymentById(id:string): Observable<FeePaymentDetails> { 
    return this.http.get<FeePaymentDetails>(`${this.apiUrl}/${id}`);
  }

  updateFeePaymentById(id:string, model:FeePaymentUpdate): Observable<FeePaymentDetails> { 
    return this.http.put<FeePaymentDetails>(`${this.apiUrl}/${id}`,model);
  }

  addFeePayment(model:FeePaymentCreate): Observable<FeePaymentDetails> { 
    return this.http.post<FeePaymentDetails>(`${this.apiUrl}`,model);
  }
}
