import { Component, OnInit } from '@angular/core';
import { LoginService } from '../shared/services/login.service';
import { NgForm } from '@angular/forms';
import { Token } from '../shared/models/token.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styles: [
  ]
})
export class LoginComponent implements OnInit {

  constructor(public service : LoginService, private router : Router) { }

  ngOnInit(): void {
  }

  onSubmit(form : NgForm){
    this.service.postLogin().subscribe({
      next: () => {
        this.router.navigate(['/main-page'])
        },
        error: (err: any) => {
          console.log(err);
        },
      }
    );
  }
}
