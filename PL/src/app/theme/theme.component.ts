import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Theme } from '../shared/models/theme.model';
import { LoginService } from '../shared/services/login.service';
import { ThemeService } from '../shared/services/theme.service';

@Component({
  selector: 'app-theme',
  templateUrl: './theme.component.html',
  styles: [
  ]
})
export class ThemeComponent implements OnInit {

  constructor(public service : ThemeService, public loginService : LoginService, private modalService: NgbModal, private route: ActivatedRoute, private router: Router) { }
  
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
      this.service.updateTheme(result).subscribe( 
        () =>{
          this.ngOnInit();
        },
        (err) => {
          console.log(err);
        });
    },
    (error) => console.log(error));
  }
  
  deleteTheme(content:any) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result : number) => {
      this.service.deleteThemeById(result).subscribe( 
        () =>{
          this.ngOnInit();
        },
        (err) => {
          console.log(err);
        });
    },
    (error) => console.log(error));
  } 

  learnTheme(themeId : number) {
    this.router.navigate(['/theme-learn-page'], { queryParams: { id: themeId } });
  }
}
