import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Theme } from '../models/theme.model';
import { UserStatistic } from '../models/user-statistic.model';
import { LoginService } from './login.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  readonly baseUrl = 'https://localhost:44303/api/statistic/';
  statistic : UserStatistic = new UserStatistic();
  constructor(private http : HttpClient,
    private loginService : LoginService) 
  { 
    this.updateStatistic();
  }

  updateStatistic() {
    this.getUserStatistic().subscribe({
      next: (res) => {
        this.statistic = res as UserStatistic;
      },
      error: (err) => {console.log(err);}
    });
  }

  getUserStatistic() {
    return this.http.get(this.baseUrl + this.loginService.getCurrentUserName());
  }

  getAllUserStatistic(){
    return this.http.get(this.baseUrl);
  }

  finishTheme(theme : Theme) { 
    if(!this.statistic.finishedThemes.some(x => x === theme))
    {
      this.statistic.finishedThemes.push(theme);
    }
    
    this.statistic.rating = this.statistic.finishedThemes.length * 26 + this.statistic.finishedCourses.length * 5;

    return this.http.put(this.baseUrl, this.statistic);
  }

  recalculateTotal() {
    this.statistic.rating = this.statistic.finishedThemes.length * 26 + this.statistic.finishedCourses.length * 5;

    return this.http.put(this.baseUrl, this.statistic);
  }

  getStatisticForCourse(courseId : number) {
    return this.http.get(this.baseUrl + `${this.statistic.id}/themesRaterForCourse/${courseId}`);
  }
}
