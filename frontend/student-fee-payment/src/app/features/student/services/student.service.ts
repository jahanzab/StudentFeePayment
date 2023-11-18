import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment.development';
import { Student } from '../models/student.model';
import { Observable } from 'rxjs';
import { StudentDetails } from '../models/student-details.model';
import { StudentCreateUpdate } from '../models/student-create-update.model';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  constructor(private http: HttpClient) { }

  private apiBaseUrl:string = environment.apiBaseUrl;
  private apiUrl = `${this.apiBaseUrl}/students`

  getAllStudents(): Observable<Student[]> { 
    return this.http.get<Student[]>(this.apiUrl);
  }

  getStudentById(id:string): Observable<StudentDetails> { 
    return this.http.get<StudentDetails>(`${this.apiUrl}/${id}`);
  }

  updateStudentById(id:string, student:StudentCreateUpdate): Observable<StudentDetails> { 
    return this.http.put<StudentDetails>(`${this.apiUrl}/${id}`,student);
  }

  addStudent(student:StudentCreateUpdate): Observable<StudentDetails> { 
    return this.http.post<StudentDetails>(`${this.apiUrl}`,student);
  }
}
