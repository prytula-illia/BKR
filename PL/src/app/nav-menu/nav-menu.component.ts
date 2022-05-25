import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { isEmpty } from 'rxjs';
import { LoginService } from '../shared/services/login.service';
import { ThemeService } from '../shared/services/theme.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {

  constructor(public loginService : LoginService, public themeService : ThemeService, public router : Router) {}
  
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
  
  searchThemes(name : string) {
    if(name)
    {
      this.themeService.themes = this.themeService.themes.filter(x => x.title.includes(name));
    }
    else
    {
      this.themeService.getAllThemes(this.themeService.courseId);
    }
  }
}
