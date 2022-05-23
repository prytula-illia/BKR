import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { HttpClientModule } from '@angular/common/http';
import { FooterComponent } from './footer/footer.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { CourseComponent } from './course/course.component';
import { RouterModule } from '@angular/router';
import { MainpageComponent } from './mainpage/mainpage.component';
import {MatDialogModule} from '@angular/material/dialog';
import {MatFormFieldModule} from '@angular/material/form-field';
 import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { ThemeComponent } from './theme/theme.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    FooterComponent,
    NavMenuComponent,
    CourseComponent,
    MainpageComponent,
    ThemeComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    MatDialogModule,
    MatFormFieldModule,
    NgbModule,
    RouterModule.forRoot([
      {path: 'main-page', component: MainpageComponent},
      {path: 'login-page', component: LoginComponent},
      {path: 'course-page', component: CourseComponent},
      {path: 'themes-page', component: ThemeComponent},
      {path: '', redirectTo: '/login-page', pathMatch: 'full'},
    ]),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
