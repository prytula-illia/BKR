import { Component, ElementRef, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Answer } from 'src/app/shared/models/answer.model';
import { PracticalTask } from 'src/app/shared/models/practical-task.model';
import { StudyingMaterial } from 'src/app/shared/models/studying-material.model';
import { Theme } from 'src/app/shared/models/theme.model';
import { ThemeService } from 'src/app/shared/services/theme.service';


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

  constructor(public service : ThemeService, private modalService: NgbModal, private route: ActivatedRoute, private router: Router) { }

  private id : number;
  public answers : Answer[] = [new Answer(), new Answer()];
  public answerQuestions : AnswerQuestion[] = [new AnswerQuestion(), new AnswerQuestion()];
  
  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.id = params['id'];
    });
  }

  createTheme(form : NgForm) {
    this.service.createTheme(this.id).subscribe( 
      () =>{
        this.service.formData = new Theme();
        this.router.navigate(['/themes-page'], { queryParams: { id: this.id } });
      },
      (err) => {
        console.log(err);
      });
  }

  addMaterial(content : any) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result : StudyingMaterial) => {
      this.service.addMaterialToFormData(result);
    },
    (error) => console.log(error));
  }

  selectTaskType(content : any) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then(
      (error) => console.log(error));
  }

  addTask(content : any) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result : PracticalTask) => {
      this.service.addTaskToFormData(result);
    },
    (error) => console.log(error));
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
    alert(arr);
    arr.forEach(element => {
      result = this.concatQuestion(result, element);
    });
    return result;
  }
}
