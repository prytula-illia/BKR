import { HttpErrorResponse, HttpEvent, HttpHandler, HttpHeaders, HttpInterceptor, HttpRequest, HttpResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Observable, tap } from "rxjs";

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
    constructor(private router : Router){}

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        var tokenStr = localStorage.getItem('id_token');
        var headers = new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${tokenStr}`
        });
        
        const resultRequest = req.clone({
            headers: headers
        });

        return next.handle(resultRequest).pipe(
            tap(
                  (event) => {
                    if (event instanceof HttpResponse)
                      console.log(event.statusText);
                  },
                  (err) => {
                    if (err instanceof HttpErrorResponse) {
                      if (err.status == 401) {
                        this.router.navigate(['/login-page']);
                      }
                      else if(err.status == 403) {
                        this.router.navigate(['/main-page']);
                      }
                      else {
                        alert(err.error);
                      }
                    }
                  }
                )
            )
    }
}