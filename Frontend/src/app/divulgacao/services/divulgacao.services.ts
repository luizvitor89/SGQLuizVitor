import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { Observable } from "rxjs";
import { map, catchError } from 'rxjs/operators';

import { DivulgacaoModel } from "../models/divulgacaoModel";
import { BaseService } from "../../core/services/base.service";

@Injectable()
export class DivulgacaoService extends BaseService {

  constructor(private http: HttpClient){ super() }    
    
    getDivulgacoes(): Observable<DivulgacaoModel[]> {
        return this.http
          .get<any>(this.UrlService + "dt/divulgacao", super.ObterAuthHeaderJson())
          .pipe(catchError(super.serviceError));
      }
    getComunicadoExterno(): Observable<any[]> {
        return this.http
          .get<any>(this.UrlService + "dt/divulgacao/ComunicadoExterno", super.ObterAuthHeaderJson())
          .pipe(catchError(super.serviceError));
      }
}
