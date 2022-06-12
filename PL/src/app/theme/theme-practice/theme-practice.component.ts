import { Component, ElementRef, OnInit, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PracticalTask } from 'src/app/shared/models/practical-task.model';
import { Theme } from 'src/app/shared/models/theme.model';
import { LoginService } from 'src/app/shared/services/login.service';
import { ThemeService } from 'src/app/shared/services/theme.service';
import { UserService } from 'src/app/shared/services/user.service';
import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';
import Swal from 'sweetalert2';
import { ThemeRating } from 'src/app/shared/models/theme-rating.model';

@Component({
  selector: 'app-theme-practice',
  templateUrl: './theme-practice.component.html',
  styles: [
  ]
})
export class ThemePracticeComponent implements OnInit {
  constructor(
    public service : ThemeService,
    private route: ActivatedRoute, 
    public loginService : LoginService,  
    public userService : UserService,
    private router : Router) { }

  @ViewChildren('answers') answers: QueryList<ElementRef>;
  private currentTaskIndex : number = 0;
  task : PracticalTask = new PracticalTask();
  theme : Theme = new Theme();
  probableAnswers : string[];
  themeRate : number;

  @ViewChild('tRate',{static: false})
  tRate: ElementRef;

  ngOnInit(): void {
    Swal.fire('', 'Loading...');
    Swal.showLoading();
    this.route.queryParams.subscribe(params => {
      var themeId = params['id'];
      this.service.getTheme(themeId).subscribe({
        next: (res) => {
          var theme = res as Theme;
          this.theme = theme;
          this.task = theme.tasks[0];
          this.probableAnswers = this.task.answers.map(x => x.content);
          Swal.close();
        }
      });
    });
  }

  drop(event: CdkDragDrop<string[]>) {
    moveItemInArray(this.probableAnswers, event.previousIndex, event.currentIndex);
  }

  goToStudyingMaterials() {
    this.router.navigate(['/theme-learn-page'], { queryParams: { id: this.theme.id } });
  }
  
  getNextTask(){
    if(!this.checkIfTaskIsCorrect()){
      Swal.fire({
        position: 'top',
        title: 'Oops!',
        text:  'Your answer is incorrect, try again.',
        icon: 'error',
        confirmButtonColor: '#4BB5AB',
      });
      return;
    }
     
    if(this.currentTaskIndex + 2 > this.theme.tasks.length) {
      Swal.fire({
        position: 'top',
        title: 'Good job student!',
        html: this.tRate.nativeElement,
        confirmButtonColor: '#4BB5AB',
      }).then(() => {
        this.userService.finishTheme(this.theme).subscribe({
          next: () => {
            var rating : ThemeRating = {
              username : this.loginService.getCurrentUserName(),
              rating : this.themeRate,
              themeId : this.theme.id
            };
            this.service.updateThemeStatistic(rating).subscribe({
                next: () => this.router.navigate(['/themes-page'], { queryParams: { id: this.theme.courseId } }),
                error: (err) => { console.log(err) } 
              });
          }
        });
      });
    }
    else {
      Swal.fire({
        position: 'top',
        title: 'Good job student!',
        text:  'Your answer is correct, keep it up!',
        icon: 'success',
        confirmButtonColor: '#4BB5AB',
      });

      this.currentTaskIndex++;
      this.task = this.theme.tasks[this.currentTaskIndex];
      this.probableAnswers = this.task.answers.map(x => x.content);
    }
  }

  checkIfTaskIsCorrect() : boolean {
    switch(this.task.type)
    {
      case 0:
        var div = this.answers.toArray()[0].nativeElement as HTMLDivElement;
        var noCheckbox = div.lastChild.firstChild as HTMLInputElement;
        var answ = this.task.answers.find(x => x.content === 'no').isCorrect;
        if(answ){
          return noCheckbox.checked;
        }
        else{
          return !noCheckbox.checked;
        }
      case 1:
        var result = true;
        this.answers.toArray().forEach((element, i) => {
          var div = element.nativeElement as HTMLDivElement;
          var answ = div.firstChild as HTMLInputElement;
          if(answ.checked != this.task.answers[i].isCorrect){
            result = false;
          }
        });
        return result;
      case 2:
        var answer = this.answers.toArray()[0].nativeElement as HTMLInputElement;
        return (answer.value.trim() === this.task.answers[0].content.trim());
      case 3:
        var result = true;
        this.answers.toArray().forEach((element, i) => {
          var div = element.nativeElement.firstChild as HTMLDivElement;
          var answ = div.lastChild as HTMLInputElement;
          if(answ.value.trim() !== this.task.answers[i].content.trim()){
            result = false;
          }
        });
        return result;
      default:
        return false;
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

  splitQuestion() : string[] {
    return this.task.question.split("________");
  }
}
