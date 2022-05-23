import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Theme } from '../models/theme.model';

@Injectable({
  providedIn: 'root'
})
export class ThemeService {

  constructor(private http : HttpClient) 
  { }

  public themes : Theme[];
  readonly baseUrl = 'https://localhost:44303/api/theme';


  getAllThemes() {
    this.http.get<Theme[]>(this.baseUrl, { headers: this.generateTokenHeaders() })
      .subscribe({
        next: (res) => { this.themes = res as Theme[]},
        error: (err) => {console.log(err);}
      }); 
  }

  updateTheme(theme : Theme) {
    var result = this.http.put(this.baseUrl + "/", theme, { headers: this.generateTokenHeaders() });
    result.subscribe({
      error: (err) => {console.log(err);}
    });
    return result;
  }

  deleteThemeById(id : number) {
    var result = this.http.delete(this.baseUrl + `/${id}`, { headers: this.generateTokenHeaders() });
    result.subscribe({
      error: (err) => {console.log(err);}
    }); 
    return result;
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
