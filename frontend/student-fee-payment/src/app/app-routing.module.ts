import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { StudentListComponent } from './features/student/student-list/student-list.component';
import { EditStudentComponent } from './features/student/edit-student/edit-student.component';
import { AddStudentComponent } from './features/student/add-student/add-student.component';
import { FeePaymentListComponent } from './features/fee-payment/fee-payment-list/fee-payment-list.component';
import { FeePaymentDetailsComponent } from './features/fee-payment/fee-payment-details/fee-payment-details.component';
import { AddFeePaymentComponent } from './features/fee-payment/add-fee-payment/add-fee-payment.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'students',
    component: StudentListComponent
  },
  {
    path: 'students/add',
    component: AddStudentComponent
  },
  {
    path: 'students/:id',
    component: EditStudentComponent
  },
  {
    path: 'fee-payments',
    component: FeePaymentListComponent
  },
  {
    path: 'fee-payments/add', component: AddFeePaymentComponent
  },
  {
    path: 'fee-payments/:id', component: FeePaymentDetailsComponent
  }


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
