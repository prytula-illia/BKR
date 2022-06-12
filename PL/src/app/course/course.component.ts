import { Component, OnInit } from '@angular/core';
import { CourseService } from '../shared/services/course.service';
import { Course } from '../shared/models/course.model';
import {NgbModal} from '@ng-bootstrap/ng-bootstrap';
import { Router } from '@angular/router';
import { LoginService } from '../shared/services/login.service';
import Swal from 'sweetalert2';

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
        Swal.fire({
          position: 'top',
          text: "Name should be atleast 5 characters.",
          icon: 'warning',
          confirmButtonColor: '#4BB5AB',
        })
      }
      else if(result.description.length < 10) {
        Swal.fire({
          position: 'top',
          text: "Description should be atleast 10 characters.",
          icon: 'warning',
          confirmButtonColor: '#4BB5AB',
        })
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
        Swal.fire({
          position: 'top',
          text: "Name should be atleast 5 characters.",
          icon: 'warning',
          confirmButtonColor: '#4BB5AB',
        })
      }
      else if(result.description.length < 10) {
        Swal.fire({
          position: 'top',
          text: "Description should be atleast 10 characters.",
          icon: 'warning',
          confirmButtonColor: '#4BB5AB',
        })
      }
      else
      {
        this.service.updateCourse(result).subscribe({
          next: () => this.ngOnInit()
        });
      }
    });
  }
  
  deleteCourse(id : number) {
    const swalWithBootstrapButtons = Swal.mixin({
      customClass: {
        confirmButton: 'btn mx-3 btn-danger',
        cancelButton: 'btn mx-3 btn-block btn-outline-dark'
      },
      buttonsStyling: false
    })
    
    swalWithBootstrapButtons.fire({
      position: 'top',
      text: 'Are you sure that you want to delete course?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Delete',
      cancelButtonText: 'Cancel',
      reverseButtons: true
    }).then((result) => {
      if (result.isConfirmed) {
        this.service.deleteCourseById(id).subscribe({
          next: () => this.ngOnInit()
        });
      }
    })
  }
  
  redirectToThemes(id : number) {
    this.router.navigate(['/themes-page'], { queryParams: { id: id } });
  }
}
