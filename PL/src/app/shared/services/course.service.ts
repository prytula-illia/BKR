import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Course } from '../models/course.model';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  constructor(private http : HttpClient) { }

  readonly baseUrl = 'https://localhost:44303/api/course';
  courses : Course[];

  getAllCourses() {
    this.http.get<Course[]>(this.baseUrl, { headers: this.generateTokenHeaders() })
      .subscribe({
        next: (res) => { this.courses = res as Course[]},
        error: (err) => {console.log(err);}
      }); 
  }

  createCourse(course : Course) {
    return this.http.post(this.baseUrl + "/", course, { headers: this.generateTokenHeaders() });
  }

  updateCourse(course : Course) {
    return this.http.put(this.baseUrl + "/", course, { headers: this.generateTokenHeaders() });
  }

  deleteCourseById(id : number) {
   return this.http.delete(this.baseUrl + `/${id}`, { headers: this.generateTokenHeaders() });
  }

  generateTokenHeaders() : HttpHeaders {
    var tokenStr = localStorage.getItem('id_token');
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${tokenStr}`
    });
    return headers;
  }
}
