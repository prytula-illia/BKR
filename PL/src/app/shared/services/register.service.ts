import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RegisterModel } from '../models/register-model.model';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  formData : RegisterModel = new RegisterModel();
  readonly baseUrl = 'https://localhost:44303/api/authorization/register';

  constructor(private http : HttpClient) { }

  register() {
    return this.http.post(this.baseUrl, this.formData);
  }
}
