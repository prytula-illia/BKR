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
  readonly baseUrl = 'https://localhost:44303/api/';

  getAllThemes(id : number) {
    this.http.get<Theme[]>(this.baseUrl + `course/${id}/theme`, { headers: this.generateTokenHeaders() })
      .subscribe({
        next: (res) => { this.themes = res as Theme[];},
        error: (err) => {console.log(err);}
      }); 
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
    var index = this.formData.studyingMaterials.indexOf(sm);
    return delete this.formData.studyingMaterials[index];
  };

  addTaskToFormData(task : PracticalTask) {
    return this.formData.tasks.push(task);
  }
  
  removeTaskFromData(task : PracticalTask) {
    var index = this.formData.tasks.indexOf(task);
    return delete this.formData.tasks[index];
  };

  generateTokenHeaders() : HttpHeaders {
    var tokenStr = localStorage.getItem('id_token');
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${tokenStr}`
    });
    return headers;
  }
}
