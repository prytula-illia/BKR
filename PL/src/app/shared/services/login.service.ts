import { Injectable } from '@angular/core'
import { Login } from '../models/login.model'
import { HttpClient } from '@angular/common/http'
import { Token } from '../models/token.model'
import * as moment from 'moment'

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http : HttpClient) { }

  formData : Login = new Login();
  readonly baseUrl = 'https://localhost:44303/api/authorization/login';

  postLogin() {
    var result = this.http.post(this.baseUrl, this.formData);
    result.subscribe((data : Token) => {
      localStorage.setItem('id_token', data.token);
      localStorage.setItem("expires_at", JSON.stringify(data.expiration.valueOf()) );
    });
    return result;
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
}
