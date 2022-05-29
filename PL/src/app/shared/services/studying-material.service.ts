import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { StudyingMaterial } from '../models/studying-material.model';

@Injectable({
  providedIn: 'root'
})
export class StudyingMaterialService {

  constructor(private http : HttpClient) { }
  readonly baseUrl = 'https://localhost:44303/api/studyingMaterial';

  updateStudyingMaterial(sm : StudyingMaterial) {
    return this.http.put(this.baseUrl, sm);
  }
}
