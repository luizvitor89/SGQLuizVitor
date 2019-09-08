import { Injectable } from "@angular/core";
import { HttpInterceptor, HttpHandler, HttpEvent, HttpRequest, HttpErrorResponse } from "@angular/common/http";
import { Router } from "@angular/router";

import { Observable } from "rxjs";
import { catchError } from 'rxjs/operators'
import { throwError } from 'rxjs';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

    constructor(private router: Router){}

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        
        return next.handle(req).pipe(catchError(err => {
            
            if(err instanceof HttpErrorResponse) {
                if(err.status === 401){
                    localStorage.removeItem('sgq.token');
                    localStorage.removeItem('sgq.user');
                    this.router.navigate(['/login']);
                }
                if (err.status === 403) {
                    this.router.navigate(['/acesso-negado']);
                }
                if (err.status === 404) {
                    this.router.navigate(['/nao-encontrado']);
                }
            }

            return throwError(err);
        }));
    }    
}