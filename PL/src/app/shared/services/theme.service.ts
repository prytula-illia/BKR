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
    this.http.get<Theme[]>(this.baseUrl + `course/${id}/theme`)
      .subscribe({
        next: (res : Theme[]) => { 
          this.courseId = id;
          this.themes = res;
        },
        error: (err) => {console.log(err);}
      }); 
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
