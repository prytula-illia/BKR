import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import * as moment from 'moment';
import { StudyingMaterial } from 'src/app/shared/models/studying-material.model';
import { Theme } from 'src/app/shared/models/theme.model';
import { UserComment } from 'src/app/shared/models/user-comment.model';
import { LoginService } from 'src/app/shared/services/login.service';
import { StudyingMaterialService } from 'src/app/shared/services/studying-material.service';
import { ThemeService } from 'src/app/shared/services/theme.service';

@Component({
  selector: 'app-theme-learn',
  templateUrl: './theme-learn.component.html',
  styles: [
  ]
})
export class ThemeLearnComponent implements OnInit {

  theme : Theme = new Theme();

  private currentMaterialIndex : number = 0;

  material : StudyingMaterial = new StudyingMaterial();

  constructor(public service : ThemeService,
    private route : ActivatedRoute,
    public loginService : LoginService,
    private router : Router,
    private studyingMaterialService : StudyingMaterialService) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      var themeId = params['id'];
      this.service.getTheme(themeId).subscribe({
        next: (res) => { this.initSetup(res as Theme) },
        error: (err) => {console.log(err);}
      });
    });
  }

  initSetup(theme : Theme) {
    this.theme = theme;
    this.material = this.theme.studyingMaterials[0];
  }

  getNextMaterial() {
    if(this.currentMaterialIndex + 2 > this.theme.studyingMaterials.length) {
      this.router.navigate(['/theme-practice-page'], { queryParams: { id: this.theme.id } });
    }
    else {
      this.currentMaterialIndex++;
      this.material = this.theme.studyingMaterials[this.currentMaterialIndex];
    }
  }

  getPrevMaterial() {
    if(this.currentMaterialIndex - 1 < 0) {
      this.material = this.theme.studyingMaterials[0];
    }
    else {
      this.currentMaterialIndex--;
      this.material = this.theme.studyingMaterials[this.currentMaterialIndex];
    }
  }

  addComment(content: UserComment) {
    this.theme.studyingMaterials[this.currentMaterialIndex].comments.push(content);
      var material = this.theme.studyingMaterials[this.currentMaterialIndex];

      this.studyingMaterialService.updateStudyingMaterial(material).subscribe(
        (err) => {
          console.log(err);
        }
      );
  }

  getCurrentDate() {
    return new Date();
  }

  getUserName() : string {
    return this.loginService.getCurrentUserName();
  }

  getBeautifulDate(date : Date) {
    return (moment(date)).format('DD-MMM-YYYY HH:mm:ss')
  }
}
