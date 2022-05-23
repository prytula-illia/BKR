import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Theme } from '../shared/models/theme.model';
import { ThemeService } from '../shared/services/theme.service';

@Component({
  selector: 'app-theme',
  templateUrl: './theme.component.html',
  styles: [
  ]
})
export class ThemeComponent implements OnInit {

  constructor(public service : ThemeService, private modalService: NgbModal) { }
  
  ngOnInit(): void {
    this.service.getAllThemes();
  }

  updateTheme(content:any) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result : Theme) => {
      this.service.updateTheme(result).subscribe( 
        () =>{
          this.ngOnInit();
        });
    });
  }
  
  deleteTheme(content:any) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result : number) => {
      this.service.deleteThemeById(result).subscribe( 
        () =>{
          this.ngOnInit();
        });
    });
  } 
}
