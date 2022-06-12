import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CommentRating } from '../models/commentrating.model';
import { StudyingMaterial } from '../models/studying-material.model';
import { UserComment } from '../models/user-comment.model';

@Injectable({
  providedIn: 'root'
})
export class StudyingMaterialService {

  constructor(private http : HttpClient) { }
  readonly baseUrl = 'https://localhost:44303/api';

  updateStudyingMaterial(sm : StudyingMaterial) {
    return this.http.put(this.baseUrl + '/studyingMaterial', sm);
  }
  
  addCommentToMaterial(materialId : number, content : UserComment) {
    return this.http.post(this.baseUrl + `/studyingMaterial/${materialId}/comment/`, content);
  }

  updateCommentRatings(rating : CommentRating) {
    return this.http.put(this.baseUrl + `/comment/updateRating`, rating);
  }
}
