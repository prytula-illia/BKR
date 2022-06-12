import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Course } from '../models/course.model';
import Swal from 'sweetalert2';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  constructor(private http : HttpClient) { }

  readonly baseUrl = 'https://localhost:44303/api/course';
  courses : Course[];

  getAllCourses() {
    Swal.fire('', 'Loading...');
    Swal.showLoading();
    this.http.get<Course[]>(this.baseUrl)
      .subscribe({
        next: (res) => { 
          this.courses = res as Course[];
          Swal.close();
        },
        error: (err) => {
          console.log(err);
          Swal.close();
        }
      }); 
  }

  getCourse(id : number) {
    return this.http.get(this.baseUrl + `/${id}`);
  }

  createCourse(course : Course) {
    return this.http.post(this.baseUrl + "/", course);
  }

  updateCourse(course : Course) {
    return this.http.put(this.baseUrl + "/", course);
  }

  deleteCourseById(id : number) {
   return this.http.delete(this.baseUrl + `/${id}`);
  }
}
