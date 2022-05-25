import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PracticalTask } from 'src/app/shared/models/practical-task.model';
import { StudyingMaterial } from 'src/app/shared/models/studying-material.model';
import { Theme } from 'src/app/shared/models/theme.model';
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
  private currentTaskIndex : number = 0;

  material : StudyingMaterial = new StudyingMaterial();
  task : PracticalTask = new PracticalTask();

  constructor(public service : ThemeService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      var themeId = params['id'];
      this.service.getTheme(themeId).subscribe({
        next: (res) => {
          var theme = res as Theme;
          this.theme = theme;
          this.task = theme.tasks[0];
          this.material = theme.studyingMaterials[0];
        },
        error: (err) => {console.log(err);}
      });
    });
  }

  getNextTask(){
    if(this.currentTaskIndex + 2 > this.theme.tasks.length) {
      this.task = this.theme.tasks[this.currentTaskIndex];
    }
    else {
      this.currentTaskIndex++;
      this.task = this.theme.tasks[this.currentTaskIndex];
    }
  }

  getPrevTask() {
    if(this.currentTaskIndex - 1 < 0) {
      this.task = this.theme.tasks[0];
    }
    else {
      this.currentTaskIndex--;
      this.task = this.theme.tasks[this.currentTaskIndex];
    }
  }

  getNextMaterial() {
    if(this.currentMaterialIndex + 2 > this.theme.studyingMaterials.length) {
      this.material = this.theme.studyingMaterials[this.currentMaterialIndex];
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
}
