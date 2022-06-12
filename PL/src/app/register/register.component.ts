import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { RegisterService } from '../shared/services/register.service';
import Swal from 'sweetalert2';

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
    try
    { 
      Swal.fire('', 'Loading...');
      Swal.showLoading();
      this.service.register().subscribe({
        next: () => {
          this.router.navigate(['/login-page'])
          Swal.close();
          },
          error: (err: any) => {
            console.log(err);
          },
        }
      );
    }
    catch
    {
      Swal.fire({
        position: 'top',
        text: "Please, enter valid data.",
        icon: 'warning',
        confirmButtonColor: '#4BB5AB',
      })
    }
  }
}
