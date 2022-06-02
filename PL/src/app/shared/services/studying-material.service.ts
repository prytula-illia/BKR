import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { StudyingMaterial } from '../models/studying-material.model';
import { UserComment } from '../models/user-comment.model';

@Injectable({
  providedIn: 'root'
})
export class StudyingMaterialService {

  constructor(private http : HttpClient) { }
  readonly baseUrl = 'https://localhost:44303/api/studyingMaterial';

  updateStudyingMaterial(sm : StudyingMaterial) {
    return this.http.put(this.baseUrl, sm);
  }
  
  addCommentToMaterial(materialId : number, content : UserComment) {
    return this.http.post(this.baseUrl + `/${materialId}/comment/`, content);
  }
}
