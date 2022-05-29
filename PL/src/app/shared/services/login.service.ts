import { Injectable } from '@angular/core'
import { Login } from '../models/login.model'
import { HttpClient } from '@angular/common/http'
import { Token } from '../models/token.model'
import * as moment from 'moment'
import jwt_decode from 'jwt-decode'

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

  logout() {
    localStorage.removeItem("id_token");
    localStorage.removeItem("expires_at");
  }

  public isLoggedIn() {
      return moment().isBefore(this.getExpiration());
  }

  isLoggedOut() {
      return !this.isLoggedIn();
  }

  getExpiration() {
      const expiration = localStorage.getItem("expires_at");
      const expiresAt = JSON.parse(expiration);
      return moment(expiresAt);
  }
  
  getDecodedToken() {
    var token = localStorage.getItem("id_token");
    return jwt_decode(token);
  }

  getCurrentUserRole() {
    var decodedToken = this.getDecodedToken();
    return decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
  }
  
  getCurrentUserName() {
    var decodedToken = this.getDecodedToken();
    return decodedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'];
  }
}
