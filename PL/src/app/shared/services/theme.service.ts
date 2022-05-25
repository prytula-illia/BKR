import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PracticalTask } from '../models/practical-task.model';
import { StudyingMaterial } from '../models/studying-material.model';
import { Theme } from '../models/theme.model';

@Injectable({
  providedIn: 'root'
})
export class ThemeService {

  constructor(private http : HttpClient) 
  { }

  public formData : Theme = new Theme();
  public themes : Theme[];
  public courseId : number;
  readonly baseUrl = 'https://localhost:44303/api/';

  getAllThemes(id : number) {
    this.http.get<Theme[]>(this.baseUrl + `course/${id}/theme`, { headers: this.generateTokenHeaders() })
      .subscribe({
        next: (res) => { 
          this.courseId = id;
          this.themes = res as Theme[];
        },
        error: (err) => {console.log(err);}
      }); 
  }

  getTheme(id : number) {
    return this.http.get(this.baseUrl + `theme/${id}`, { headers: this.generateTokenHeaders() });
  }

  createTheme(id : number) {
    return this.http.post(this.baseUrl + `course/${id}/theme`, this.formData, { headers: this.generateTokenHeaders() });
  }

  updateTheme(theme : Theme) {
    return this.http.put(this.baseUrl + "theme/", theme, { headers: this.generateTokenHeaders() });
  }

  deleteThemeById(id : number) {
    return this.http.delete(this.baseUrl + `theme/${id}`, { headers: this.generateTokenHeaders() });
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

  generateTokenHeaders() : HttpHeaders {
    var tokenStr = localStorage.getItem('id_token');
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${tokenStr}`
    });
    return headers;
  }
}
