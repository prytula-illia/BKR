import { Component, OnInit } from '@angular/core';
import { LoginService } from '../shared/services/login.service';
import { NgForm } from '@angular/forms';
import { Token } from '../shared/models/token.model';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styles: [
  ]
})
export class LoginComponent implements OnInit {

  constructor(public service : LoginService, private router : Router) { }

  ngOnInit(): void {
    if(this.service.isLoggedIn()) {
      this.router.navigate(['/main-page']);
    }
  }

  onSubmit(form : NgForm){
    Swal.fire('', 'Loading...');
    Swal.showLoading();
    this.service.postLogin().subscribe((data : Token) => {
      localStorage.setItem('id_token', data.token);
      localStorage.setItem("expires_at", JSON.stringify(data.expiration.valueOf()) );
      this.router.navigate(['/main-page'])
      Swal.close();
    });
  }
}
