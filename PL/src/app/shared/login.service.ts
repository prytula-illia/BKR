import { Injectable } from '@angular/core';
import { Login } from './login.model';
import { HttpClient } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http : HttpClient) { }

  formData : Login = new Login();
  readonly baseUrl = 'https://localhost:44303/api/authorization/login';

  postLogin() {
    return this.http.post(this.baseUrl, this.formData);
  }
  
}
