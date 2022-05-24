import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { RegisterService } from '../shared/services/register.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styles: [
  ]
})
export class RegisterComponent implements OnInit {

  constructor(public service : RegisterService, private router : Router) { }

  ngOnInit(): void {
  }

  onSubmit(form : NgForm){
    this.service.register().subscribe({
      next: () => {
        this.router.navigate(['/login-page'])
        },
        error: (err: any) => {
          console.log(err);
        },
      }
    );
  }
}
