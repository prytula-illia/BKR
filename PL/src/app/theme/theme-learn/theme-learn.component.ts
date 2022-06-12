import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import * as moment from 'moment';
import { CommentRating } from 'src/app/shared/models/commentrating.model';
import { StudyingMaterial } from 'src/app/shared/models/studying-material.model';
import { Theme } from 'src/app/shared/models/theme.model';
import { UserComment } from 'src/app/shared/models/user-comment.model';
import { LoginService } from 'src/app/shared/services/login.service';
import { StudyingMaterialService } from 'src/app/shared/services/studying-material.service';
import { ThemeService } from 'src/app/shared/services/theme.service';
import Swal from 'sweetalert2';

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
    Swal.fire('', 'Loading...');
    Swal.showLoading();
    this.route.queryParams.subscribe(params => {
      var themeId = params['id'];
      this.service.getTheme(themeId).subscribe({
        next: (res) => { 
          this.initSetup(res as Theme);
          Swal.close(); 
        },
        error: (err) => {
          console.log(err);
          Swal.close(); 
        }
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

  addComment(comment: UserComment) {
    if(comment.content.length < 4)
    {
      Swal.fire({
        position: 'top',
        text:  'Comment should be atleast 4 characters long.',
        icon: 'warning',
        confirmButtonColor: '#4BB5AB',
      });
      return;
    }

    this.theme.studyingMaterials[this.currentMaterialIndex].comments.push(comment);
      var material = this.theme.studyingMaterials[this.currentMaterialIndex];

      this.studyingMaterialService.addCommentToMaterial(material.id, comment).subscribe(
        (err) => {
          console.log(err);
        }
      );
  }

  searchComments(content : string) {
    if(content)
    {
      this.material.comments = this.material.comments.filter(x => x.content.toLowerCase().includes(content.toLowerCase()));
    }
    else
    {
      this.ngOnInit();
    }
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

  likeComment(comment : UserComment) {
    var currentUserName = this.loginService.getCurrentUserName();
    var c = comment.commentRatings.find(x => x.username == currentUserName);
    var rating: CommentRating;
    if(c)
    {
      rating = {
        commentId : comment.id,
        like : !c.like,
        dislike : false,
        username : currentUserName
      };
    }
    else
    {
      rating = {
        commentId : comment.id,
        like : true,
        dislike : false,
        username : currentUserName
      };
    }
    this.studyingMaterialService.updateCommentRatings(rating).subscribe({
      next : () => {this.ngOnInit()},
      error: (err) => {
        console.log(err);
      }
    });
  }

  dislikeComment(comment : UserComment) {
    var currentUserName = this.loginService.getCurrentUserName();
    var c = comment.commentRatings.find(x => x.username == currentUserName);
    var rating: CommentRating;
    if(c)
    {
      rating = {
        commentId : comment.id,
        like : false,
        dislike : !c.dislike,
        username : currentUserName
      };
    }
    else
    {
      rating = {
        commentId : comment.id,
        like : false,
        dislike : true,
        username : currentUserName
      };
    }
    this.studyingMaterialService.updateCommentRatings(rating).subscribe({
      next : () => {this.ngOnInit()},
      error: (err) => {
        console.log(err);
      }
    });
  }

  calculateLikes(comment : UserComment) : number {
    if(comment.commentRatings)
    {
      return comment.commentRatings.filter(x => x.like).length;
    }
    else
    {
      return 0;
    }
  }
  
  calculateDislikes(comment : UserComment) : number {
    if(comment.commentRatings)
    {
      return comment.commentRatings.filter(x => x.dislike).length;
    }
    else
    {
      return 0;
    }
  }
}
