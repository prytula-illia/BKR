import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PracticalTask } from '../models/practical-task.model';
import { StudyingMaterial } from '../models/studying-material.model';
import { Theme } from '../models/theme.model';
import Swal from 'sweetalert2';
import { ThemeRating } from '../models/theme-rating.model';

@Injectable({
  providedIn: 'root'
})
export class ThemeService {

  constructor(private http : HttpClient) 
  { }

  public formData : Theme = new Theme();
  public themes : Theme[];
  public ratings : number[] = [];
  public courseId : number;
  readonly baseUrl = 'https://localhost:44303/api/';

  getAllThemes(id : number) {
    Swal.fire('', 'Loading...');
    Swal.showLoading();
    this.http.get<Theme[]>(this.baseUrl + `course/${id}/theme`)
      .subscribe({
        next: (res : Theme[]) => { 
          this.courseId = id;
          this.themes = res;
          Swal.close();
          this.recalculateRatings(res);
        
        },
        error: (err) => {console.log(err);}
      }); 
  }

  recalculateRatings(res : Theme[]) {
    this.ratings = [];
    res.forEach((t) => {
      var res = t.themeRatings.map(x => x.rating).reduce((a,b) => a + b, 0) / t.themeRatings.length;
      this.ratings.push(res);
      }
    )
  }

  getThemesForCourse(id : number) {
    return this.http.get(this.baseUrl + `course/${id}/theme`);
  }

  getTheme(id : number) {
    return this.http.get(this.baseUrl + `theme/${id}`);
  }

  createTheme(id : number) {
    if(this.formData.tasks.length < 1 || this.formData.studyingMaterials.length < 1)
    {
      throw "Theme should contain atleast 1 studying material and atleast 1 task";
    }
    return this.http.post(this.baseUrl + `course/${id}/theme`, this.formData);
  }

  updateTheme(theme : Theme) {
    return this.http.put(this.baseUrl + "theme/", theme);
  }

  updateThemeStatistic(rating : ThemeRating) {
    return this.http.put(this.baseUrl + "theme/updateRating/", rating);
  }

  deleteThemeById(id : number) {
    return this.http.delete(this.baseUrl + `theme/${id}`);
  }

  addMaterialToFormData(result : StudyingMaterial) {
    return this.formData.studyingMaterials.push(result);
  }

  removeMaterialFromData(sm : StudyingMaterial) {
    this.removeFromArray(this.formData.studyingMaterials, sm);
  };

  addTaskToFormData(task : PracticalTask) {
    return this.formData.tasks.push(task);
  }
  
  removeTaskFromData(task : PracticalTask) {
    this.removeFromArray(this.formData.tasks, task);
  };

  removeFromArray(arr: any[], element: any) {
    const index = arr.indexOf(element, 0);
    if (index > -1) {
      arr.splice(index, 1);
    }
  }
}
