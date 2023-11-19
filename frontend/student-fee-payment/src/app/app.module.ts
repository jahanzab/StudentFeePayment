import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './core/components/navbar/navbar.component';
import { HomeComponent } from './home/home.component';
import { StudentListComponent } from './features/student/student-list/student-list.component';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import { EditStudentComponent } from './features/student/edit-student/edit-student.component';
import { FormsModule } from '@angular/forms';
import { SpinnerComponent } from './core/components/spinner/spinner.component';
import { LoadingInterceptor } from './core/components/interceptors/loading';
import { AddStudentComponent } from './features/student/add-student/add-student.component';
import { FeePaymentListComponent } from './features/fee-payment/fee-payment-list/fee-payment-list.component';
import { FeePaymentDetailsComponent } from './features/fee-payment/fee-payment-details/fee-payment-details.component';
import { AddFeePaymentComponent } from './features/fee-payment/add-fee-payment/add-fee-payment.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    StudentListComponent,
    EditStudentComponent,
    SpinnerComponent,
    AddStudentComponent,
    FeePaymentListComponent,
    FeePaymentDetailsComponent,
    AddFeePaymentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
