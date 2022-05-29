import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from '../shared/services/login.service';
import { ThemeService } from '../shared/services/theme.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {

  constructor(public loginService : LoginService, public router : Router) {}
  
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  logout() {
    this.loginService.logout();
  }
  
  goToLoginPage() {
    this.router.navigate(['login-page']);
  }
}
