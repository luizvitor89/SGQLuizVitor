import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { Observable } from "rxjs";
import { map, catchError } from 'rxjs/operators';

import { IncidenteModel } from "../models/incidenteModel";
import { TipoOcorrenciaModel } from "../models/tipoOcorrenciaModel";
import { InsumoModel } from "../models/insumoModel";
import { SetorModel } from "../models/setorModel";
import { StatusModel } from "../models/statusModel";
import { BaseService } from "../../core/services/base.service";

@Injectable()
export class IncidentesService extends BaseService {

  constructor(private http: HttpClient){ super() }    
    
    getIncidentes(): Observable<IncidenteModel[]> {
        return this.http
          .get<any>(this.UrlService + "cip/ocorrencia", super.ObterAuthHeaderJson())
          .pipe(catchError(super.serviceError));
      }

    getTipoOcorrencia(): Observable<TipoOcorrenciaModel[]> {
        return this.http
          .get<any>(this.UrlService + "cip/tipoOcorrencia", super.ObterAuthHeaderJson())
          .pipe(catchError(super.serviceError));
      }

    getInsumo(): Observable<InsumoModel[]> {
        return this.http
          .get<any>(this.UrlService + "cip/insumo", super.ObterAuthHeaderJson())
          .pipe(catchError(super.serviceError));
      }

    getSetor(): Observable<SetorModel[]> {
        return this.http
          .get<any>(this.UrlService + "cip/setor", super.ObterAuthHeaderJson())
          .pipe(catchError(super.serviceError));
      }

    getStatus(): Observable<StatusModel[]> {
        return this.http
          .get<any>(this.UrlService + "cip/status", super.ObterAuthHeaderJson())
          .pipe(catchError(super.serviceError));
      }

    createIncidente(incidenteModel: IncidenteModel): Observable<any> {

        let response = this.http
          .post(this.UrlService + "cip/ocorrencia", incidenteModel, super.ObterAuthHeaderJson())
          .pipe(map(super.extractData))
          .pipe(catchError(super.serviceError))
    
        return response;
      }
}
