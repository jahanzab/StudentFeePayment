import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment.development';
import { Student } from '../models/student.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  constructor(private http: HttpClient) { }

  private apiBaseUrl:string = environment.apiBaseUrl;

  getAllStudents(): Observable<Student[]> { 
    console.log('calling student api...');
    let url = `${this.apiBaseUrl}/students`
    return this.http.get<Student[]>(url);
  }
}
