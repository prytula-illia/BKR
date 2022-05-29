import { Component, OnInit } from '@angular/core';
import { Course } from '../shared/models/course.model';
import { UserStatistic } from '../shared/models/user-statistic.model';
import { CourseService } from '../shared/services/course.service';
import { LoginService } from '../shared/services/login.service';
import { UserService } from '../shared/services/user.service';

@Component({
  selector: 'app-userstatistic',
  templateUrl: './userstatistic.component.html',
  styles: [
  ]
})
export class UserstatisticComponent implements OnInit {

  constructor(public userService : UserService, public loginService : LoginService, public courseService : CourseService) 
  {     
    this.userService.getUserStatistic().subscribe({
      next: (res) => {
        this.statistic = res as UserStatistic;
        this.updateStatistic();
        this.userName = this.loginService.getCurrentUserName();
        this.userRole = this.loginService.getCurrentUserRole();
      }
    });
  }

  userName : string;
  userRole : string;
  statistic : UserStatistic = new UserStatistic();
  coursesStatistic : [courseName : string, themesRate : number, score : number][] = [];
  finishedCoursesCount : number;

  ngOnInit(): void {
    this.userService.getUserStatistic().subscribe({
      next: (res) => {
        this.statistic = res as UserStatistic;
        this.updateStatistic();
        this.userName = this.loginService.getCurrentUserName();
        this.userRole = this.loginService.getCurrentUserRole();
      }
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
