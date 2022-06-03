import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Theme } from '../shared/models/theme.model';
import { LoginService } from '../shared/services/login.service';
import { ThemeService } from '../shared/services/theme.service';
import { UserService } from '../shared/services/user.service';

@Component({
  selector: 'app-theme',
  templateUrl: './theme.component.html',
  styles: [
  ]
})
export class ThemeComponent implements OnInit {

  constructor(
    public service : ThemeService, 
    public loginService : LoginService, 
    private modalService: NgbModal, 
    private route: ActivatedRoute, 
    private router: Router,
    private userService : UserService) { }
  
  private id : number;
  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.id = params['id'];
    });
    this.service.getAllThemes(this.id);
  }

  createTheme() {
    this.router.navigate(['/theme-create-page'], { queryParams: { id: this.id } });
  }

  updateTheme(content:any) {    
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result : Theme) => {
      if(result.title.length < 5)
      {
        alert('Theme title should be atleast 5 characters long.');
        return;
      }
      if(result.description.length < 10)
      {
        alert('Theme description should be atleast 10 characters long.');
        return;
      }
      this.service.updateTheme(result).subscribe({
        next: () => this.ngOnInit()
      });
    });
  }
  
  deleteTheme(content:any) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result : number) => {
      this.service.deleteThemeById(result).subscribe({
        next: () => this.ngOnInit()
      });
    });
  } 
  
  searchThemes(name : string) {
    if(name)
    {
      this.service.themes = this.service.themes.filter(x => x.title.toLowerCase().includes(name.toLowerCase()));
    }
    else
    {
      this.service.getAllThemes(this.service.courseId);
    }
  }

  learnTheme(themeId : number) {
    this.router.navigate(['/theme-learn-page'], { queryParams: { id: themeId } });
  }

  isThemeFinished(themeId : number) {
    if(this.userService.statistic && this.userService.statistic.finishedThemes)
      return this.userService.statistic.finishedThemes.findIndex(x => x.id == themeId) !== -1;
    return false;
  }
}
