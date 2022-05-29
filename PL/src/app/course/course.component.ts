import { Component, OnInit } from '@angular/core';
import { CourseService } from '../shared/services/course.service';
import { Course } from '../shared/models/course.model';
import {NgbModal} from '@ng-bootstrap/ng-bootstrap';
import { Router } from '@angular/router';
import { LoginService } from '../shared/services/login.service';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styles: [
  ]
})
export class CourseComponent implements OnInit {
  
  constructor(public service: CourseService, public loginService : LoginService,private modalService: NgbModal, private router: Router) { }

  ngOnInit(): void {
    this.service.getAllCourses();
  }

  createCourse(content:any) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result : Course) => {
      if(result.name.length < 5){
        alert("Name should be atleast 5 characters.")
      }
      else if(result.description.length < 10) {
        alert("Description should be atleast 10 characters.")
      }
      else
      {
        this.service.createCourse(result).subscribe({
          next: () => this.ngOnInit()
        });
      }
    });
  }

  updateCourse(content:any) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result : Course) => {
      if(result.name.length < 5){
        alert("Name should be atleast 5 characters.")
      }
      else if(result.description.length < 10) {
        alert("Description should be atleast 10 characters.")
      }
      else
      {
        this.service.updateCourse(result).subscribe({
          next: () => this.ngOnInit()
        });
      }
    });
  }
  
  deleteCourse(content:any) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result : number) => {
      this.service.deleteCourseById(result).subscribe({
        next: () => this.ngOnInit()
      });
    });
  }
  
  redirectToThemes(id : number) {
    this.router.navigate(['/themes-page'], { queryParams: { id: id } });
  }
}
