import { Component, OnInit } from '@angular/core';
import { LoginService } from '../shared/login.service';
import { NgForm } from '@angular/forms';
import { Token } from '../shared/token.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styles: [
  ]
})
export class LoginComponent implements OnInit {

  constructor(public service : LoginService) { }

  ngOnInit(): void {
  }

  onSubmit(form : NgForm){
    this.service.postLogin().subscribe(
      res => {
        var token = res as Token;
        alert("Expiration date: " + token.expiration + "\n" +
              "Bearer token: " + token.token);
      },
      err => { console.log(err); }
    )
  }
}
