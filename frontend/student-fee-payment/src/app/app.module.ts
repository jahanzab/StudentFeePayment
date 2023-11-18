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

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    StudentListComponent,
    EditStudentComponent,
    SpinnerComponent
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
