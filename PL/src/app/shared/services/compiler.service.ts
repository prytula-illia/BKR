import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Code } from '../models/code.model';

@Injectable({
  providedIn: 'root'
})
export class CompilerService {

  constructor(private http : HttpClient) { }

  readonly baseUrl = 'https://localhost:44303/api/compiler/';

  compileCode(code : string) {
    var dto : Code = {
      codeToCompile : code
    };
    return this.http.post(this.baseUrl, dto);
  }
}
