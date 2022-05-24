import { Component, OnInit } from '@angular/core';
import { CourseService } from '../shared/services/course.service';
import { Course } from '../shared/models/course.model';
import {NgbModal} from '@ng-bootstrap/ng-bootstrap';
import { Router } from '@angular/router';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styles: [
  ]
})
export class CourseComponent implements OnInit {
  
  constructor(public service: CourseService, private modalService: NgbModal, private router: Router) { }

  ngOnInit(): void {
    this.service.getAllCourses();
  }

  createCourse(content:any) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result : Course) => {
      this.service.createCourse(result).subscribe( 
        () =>{
          this.ngOnInit();
        },
        (err) => {
          console.log(err);
        });
    });
  }

  updateCourse(content:any) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result : Course) => {
      this.service.updateCourse(result).subscribe( 
        () =>{
          this.ngOnInit();
        },
        (err) => {
          console.log(err);
        });
    });
  }
  
  deleteCourse(content:any) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result : number) => {
      this.service.deleteCourseById(result).subscribe( 
        () =>{
          this.ngOnInit();
        },
        (err) => {
          console.log(err);
        });
    });
  }
  
  redirectToThemes(id : number) {
    this.router.navigate(['/themes-page'], { queryParams: { id: id } });
  }
}
