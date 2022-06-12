import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Course } from '../shared/models/course.model';
import { UserStatistic } from '../shared/models/user-statistic.model';
import { CourseService } from '../shared/services/course.service';
import { LoginService } from '../shared/services/login.service';
import { UserService } from '../shared/services/user.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-userstatistic',
  templateUrl: './userstatistic.component.html',
  styles: [
  ]
})
export class UserstatisticComponent implements OnInit {

  constructor(public userService : UserService, 
    private modalService: NgbModal,
    public loginService : LoginService,
    public courseService : CourseService) 
  {     
    this.userService.getUserStatistic().subscribe({
      next: (res) => {
        this.statistic = res as UserStatistic;
        this.updateStatistic();
        this.userName = this.loginService.getCurrentUserName();
        this.userRole = this.loginService.getCurrentUserRole();
      }
    });
    this.getAllUserStatistic();
  }

  userName : string;
  userRole : string;
  statistic : UserStatistic = new UserStatistic();
  coursesStatistic : [courseName : string, themesRate : number, score : number][] = [];
  finishedCoursesCount : number;
  usersStatistic : UserStatistic[];

  ngOnInit(): void {
    Swal.fire('', 'Loading...');
    Swal.showLoading();
    this.userService.getUserStatistic().subscribe({
      next: (res) => {
        this.statistic = res as UserStatistic;
        this.updateStatistic();
        this.userName = this.loginService.getCurrentUserName();
        this.userRole = this.loginService.getCurrentUserRole();
        Swal.close();
      }
    });
  }

  getAllUserStatistic() {
    this.userService.getAllUserStatistic().subscribe({
      next: (res : UserStatistic[]) => {
        this.usersStatistic = res;
      },
      error: (err) => console.log(err)
    });
  }

  grantRole(content : any) {
    this.modalService.open(content, {size: 'lg'}).result.then((result : string) => {
      if(result.length < 1)
      {
        Swal.fire({
          position: 'top',
          text:  'Check if you entered correct username.',
          icon: 'warning',
          confirmButtonColor: '#4BB5AB',
        });
        return;
      }
        
      Swal.fire('', 'Loading...');
      Swal.showLoading();
      this.loginService.grantRole(result).subscribe({
        next: () => {
          Swal.close();
          Swal.fire({
            position: 'top',
            title: 'Success',
            text:  'User succesefully granted by ExpiriencedUser role.',
            icon: 'success',
            confirmButtonColor: '#4BB5AB',
          });
          this.ngOnInit()
        }
      });
    });
  }

  updateCourseCount() {
    this.finishedCoursesCount = this.coursesStatistic.filter(x => x[1] == 100).length;
  }

  updateStatistic() {
    if(this.statistic.id === 0)
    {
      return;
    }
    this.coursesStatistic = [];
    var uniqueCourseIds = [ ... new Set(this.statistic.finishedThemes.map((x) => x.courseId))];
    uniqueCourseIds.forEach((el, i) => {
      this.coursesStatistic.push(['',0,0]);
      this.courseService.getCourse(el).subscribe({
        next: (res : Course) => {
          this.coursesStatistic[i][0] = res.name;
        },
        error: (err) => console.log(err) 
      });
      this.userService.getStatisticForCourse(el).subscribe({
        next: (res : number) => {
          this.coursesStatistic[i][1] = res*100;
          this.updateCourseCount();
        },
        error: (err) => console.log(err)
      });
      this.coursesStatistic[i][2] = this.statistic.finishedThemes.filter(x => x.courseId === el).length * 26;
    });
  }
}
