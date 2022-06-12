import { Component, ElementRef, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Answer } from 'src/app/shared/models/answer.model';
import { PracticalTask } from 'src/app/shared/models/practical-task.model';
import { StudyingMaterial } from 'src/app/shared/models/studying-material.model';
import { Theme } from 'src/app/shared/models/theme.model';
import { LoginService } from 'src/app/shared/services/login.service';
import { ThemeService } from 'src/app/shared/services/theme.service';
import Swal from 'sweetalert2';

class AnswerQuestion {
  answer : string = '';
  question : string = '';
}

@Component({
  selector: 'app-theme-create',
  templateUrl: './theme-create.component.html',
  styles: [
  ]
})
export class ThemeCreateComponent implements OnInit {

  constructor(public service : ThemeService,
     private modalService: NgbModal,
      private route: ActivatedRoute,
      private loginService : LoginService,
      private router: Router) { }

  private id : number;
  public answers : Answer[] = [new Answer(), new Answer()];
  public answerQuestions : AnswerQuestion[] = [new AnswerQuestion(), new AnswerQuestion()];
  
  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.id = params['id'];
    });
  }

  createTheme(form : NgForm) {
    try{
      this.service.formData.createdByUser = this.loginService.getCurrentUserName();
      this.service.createTheme(this.id).subscribe({
        next: () => {
          this.service.formData = new Theme();
          this.router.navigate(['/themes-page'], { queryParams: { id: this.id } });
        },
      });
    }
    catch(ex)
    {
      Swal.fire({
        position: 'top',
        text:  ex.message,
        icon: 'warning',
        confirmButtonColor: '#4BB5AB',
      });
    }
  }

  addMaterial(content : any) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result : StudyingMaterial) => {
      if(result.title.length < 5){
        Swal.fire({
          position: 'top',
          text:  'Title should be atleast 5 characters long.',
          icon: 'warning',
          confirmButtonColor: '#4BB5AB',
        });
      }
      else if(result.content.length < 10){
        Swal.fire({
          position: 'top',
          text:  'Content should be atleast 10 characters.',
          icon: 'warning',
          confirmButtonColor: '#4BB5AB',
        });
      }
      else {
        this.service.addMaterialToFormData(result);
      }
    },
    (error) => console.log(error));
  }

  selectTaskType(content : any) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then();
  }

  addTask(content : any) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result : PracticalTask) => {
      if(result.question.length < 9){
        Swal.fire({
          position: 'top',
          text:  'Question should be atleast 9 characters long.',
          icon: 'warning',
          confirmButtonColor: '#4BB5AB',
        });
      }
      if(result.answers.find(x => x.content.length < 1))
      {
        Swal.fire({
          position: 'top',
          text:  'Answer should contain atleast 1 character.',
          icon: 'warning',
          confirmButtonColor: '#4BB5AB',
        });
        return;
      }
      if(result.type === 1 && result.answers.length < 2)
      {
        Swal.fire({
          position: 'top',
          text:  'This task should contain atleast 2 answers.',
          icon: 'warning',
          confirmButtonColor: '#4BB5AB',
        });
        return;
      }

      this.service.addTaskToFormData(result);
    });
  }

  removeTask(task : PracticalTask) {
    this.service.removeTaskFromData(task);
  }

  removeMaterial(sm : StudyingMaterial) {
    this.service.removeMaterialFromData(sm);
  }

  addAnswer() {
    this.answers.push(new Answer());
  }

  removeAnswer() {
    this.answers.pop();
  }


  addAnswerQuestion() {
    this.answerQuestions.push(new AnswerQuestion());
  }

  removeAnswerQuestion() {
    this.answerQuestions.pop();
  }

  getOnlyAnswers(arr : AnswerQuestion[]) {
    var result : Answer[] = [];
    arr.forEach(element => {
      result.push({
        id: 0,
        content: element.answer,
        isCorrect: true
      });
    });
    return result;
  }

  getOnlyQuestions(arr : AnswerQuestion[]) {
    var result : string[] = [];
    arr.forEach(element => {
      result.push(element.question);
    });
    return result;
  }

  concatQuestion(start : string, end : string) : string {
    return `${start}________${end}`;
  }

  concatQuestions(start : string, arr : string[]) : string {
    var result = start;
    arr.forEach(element => {
      result = this.concatQuestion(result, element);
    });
    return result;
  }

  generateQuestions(mainQuestion : string, first : string, rest : string[]) : string {
    var result = this.concatQuestions(first, rest);
    return this.concatQuestion(mainQuestion, result);
  }
}
