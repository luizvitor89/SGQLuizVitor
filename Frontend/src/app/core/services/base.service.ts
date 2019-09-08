import { HttpHeaders } from "@angular/common/http";

import { throwError } from 'rxjs';

export abstract class BaseService {
  protected UrlService: string = "http://localhost:59564/api/";

    protected ObterHeaderJson(){
        return {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        };
    }

    protected ObterAuthHeaderJson(){
        return {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${this.obterTokenUsuario()}`
            })
        };
    }

    protected ObterAuthHeaderUpload(){
        return {
            headers: new HttpHeaders({
                'Authorization': `Bearer ${this.obterTokenUsuario()}`
            })
        };
    }

    public obterUsuario() {
        return JSON.parse(localStorage.getItem('sgq.user'));
    }

    protected obterTokenUsuario(): string {
        return localStorage.getItem('sgq.token');
    }

    protected extractData(response: any){
        return response || {};
    }

    protected serviceError(error: Response | any){
        let errMsg: string;

        if (error instanceof Response) {

            errMsg = `${error.status} - ${error.statusText || ''}`;
        }
        else {
            errMsg = error.message ? error.message : error.toString();
        }
        console.error(error);
        return throwError(error);
    }
}