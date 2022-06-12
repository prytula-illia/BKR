import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FooterComponent } from './footer/footer.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { CourseComponent } from './course/course.component';
import { RouterModule } from '@angular/router';
import { MainpageComponent } from './mainpage/mainpage.component';
import {MatDialogModule} from '@angular/material/dialog';
import {MatFormFieldModule} from '@angular/material/form-field';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { ThemeComponent } from './theme/theme.component';
import { RegisterComponent } from './register/register.component';
import { ThemeCreateComponent } from './theme/theme-create/theme-create.component';
import { ThemeLearnComponent } from './theme/theme-learn/theme-learn.component';
import { UserstatisticComponent } from './userstatistic/userstatistic.component';
import { ThemePracticeComponent } from './theme/theme-practice/theme-practice.component';
import { AuthInterceptor } from './shared/auth.interceptor';
import { ErrorComponent } from './error/error.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { CompilerComponent } from './compiler/compiler.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    FooterComponent,
    NavMenuComponent,
    CourseComponent,
    MainpageComponent,
    ThemeComponent,
    RegisterComponent,
    ThemeCreateComponent,
    ThemeLearnComponent,
    UserstatisticComponent,
    ThemePracticeComponent,
    ErrorComponent,
    ThemePracticeComponent,
    CompilerComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    MatDialogModule,
    MatFormFieldModule,
    NgbModule,
    DragDropModule,
    RouterModule.forRoot([
      {path: 'main-page', component: MainpageComponent},
      {path: 'login-page', component: LoginComponent},
      {path: 'register-page', component: RegisterComponent},
      {path: 'course-page', component: CourseComponent},
      {path: 'themes-page', component: ThemeComponent},
      {path: 'theme-create-page', component: ThemeCreateComponent},
      {path: 'theme-learn-page', component: ThemeLearnComponent},
      {path: 'theme-practice-page', component: ThemePracticeComponent},
      {path: 'account-page', component: UserstatisticComponent},
      {path: 'compiler-page', component: CompilerComponent},
      {path: '', redirectTo: '/main-page', pathMatch: 'full'},
      {path: '**', component: ErrorComponent},
    ]),
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
