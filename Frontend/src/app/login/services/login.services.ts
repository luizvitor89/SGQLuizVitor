import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { Observable } from "rxjs";
import { map, catchError } from 'rxjs/operators';

import { LoginModel } from "../models/loginModel";
import { BaseService } from "../../core/services/base.service";

@Injectable()
export class LoginService extends BaseService {

  constructor(private http: HttpClient){ super() }    
    
    login(loginModel: LoginModel) : Observable<LoginModel> {

        let response = this.http
            .post(this.UrlService + "ologin", loginModel, super.ObterHeaderJson())
            .pipe(map(super.extractData))
            .pipe(catchError(super.serviceError))
            
        return response;
    }
}
