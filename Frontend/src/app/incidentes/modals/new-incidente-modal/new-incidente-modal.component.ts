import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { ToastController, ModalController, LoadingController } from '@ionic/angular';
import { IncidentesService } from "../../services/incidentes.services";
import { TipoOcorrenciaModel } from "../../models/tipoOcorrenciaModel";
import { InsumoModel } from "../../models/insumoModel";
import { SetorModel } from "../../models/setorModel";
import { StatusModel } from "../../models/statusModel";
import { IncidenteModel } from "../../models/incidenteModel";

@Component({
  selector: 'app-new-incidente-modal',
  templateUrl: './new-incidente-modal.component.html',
  styleUrls: ['./new-incidente-modal.component.scss'],
})
export class NewIncidenteModalComponent implements OnInit {
  
  public errors: any[] = [];
  createIncidenteForm: FormGroup;
  public isLoading = false;
  public tipoOcorrenciaModel: TipoOcorrenciaModel[];
  public insumoModel: InsumoModel[];
  public setorModel: SetorModel[];
  public statusModel: StatusModel[];
  public incidenteModel: IncidenteModel;

  constructor(private formBuilder: FormBuilder,
    public toastController: ToastController,
    private modalController: ModalController,
    public loadingController: LoadingController,
    public incidentesService: IncidentesService) { }

  ngOnInit() {

    this.presentLoading();
      this.incidentesService.getInsumo()
        .subscribe(
          result => { this.onGetInsumoComplete(result) },
          fail => { this.onError(fail) }
        );  
        this.incidentesService.getSetor()
        .subscribe(
          result => { this.onGetSetorComplete(result) },
          fail => { this.onError(fail) }
        );  
        this.incidentesService.getStatus()
        .subscribe(
          result => { this.onGetStatusComplete(result) },
          fail => { this.onError(fail) }
        );
        this.incidentesService.getTipoOcorrencia()
        .subscribe(
          result => { this.onGetTipoOcorrenciaComplete(result) },
          fail => { this.onError(fail) }
        );  

    this.createIncidenteForm = this.formBuilder.group({
      titulo: new FormControl('', Validators.compose([Validators.required])),
      prioridade: new FormControl('', Validators.compose([Validators.required])),
      descricao: new FormControl('', Validators.compose([Validators.required])),
      setorId: new FormControl(),
      consequencias: new FormControl(),
      insumoId: new FormControl(),
      tipoOcorrenciaId: new FormControl(),
      statusId: new FormControl(),
    });
  }

  onGetTipoOcorrenciaComplete(response: TipoOcorrenciaModel[]): void {
    this.tipoOcorrenciaModel = response;
  }
  onGetInsumoComplete(response: InsumoModel[]): void {
    this.insumoModel = response;
  }
  onGetSetorComplete(response: SetorModel[]): void {
    this.setorModel = response;
  }
  onGetStatusComplete(response: StatusModel[]): void {
    this.statusModel = response;
    this.dismissLoading();
  }

  closeModal() {
    this.modalController.dismiss();
  }

  newGuid() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {
      var r = Math.random() * 16 | 0,
        v = c == 'x' ? r : (r & 0x3 | 0x8);
      return v.toString(16);
    });
  }

  validation_messages = {
    'titulo': [
      { type: 'required', message: 'O titulo é obrigatório' }
    ]
  };

  createIncidente() {
    if (this.createIncidenteForm.valid) {

      var today = new Date();
      var date = today.getFullYear()+'-'+
                ((today.getMonth()+1) < 10 ? "0" + (today.getMonth()+1): (today.getMonth()+1))+'-'+
                (today.getDate() < 10 ? "0" + today.getDate(): today.getDate());

      var time = (today.getHours() < 10 ? "0" + today.getHours(): today.getHours()) + 
            ":" + (today.getMinutes() < 10 ? "0" + today.getMinutes(): today.getMinutes()) + 
            ":" + (today.getSeconds() < 10 ? "0" + today.getSeconds(): today.getSeconds());
      var dateTime = date+'T'+time;

      this.incidenteModel = new IncidenteModel();
      this.incidenteModel.ocorrenciaId = this.newGuid();
      this.incidenteModel.dataHora = dateTime;
      this.incidenteModel.ativo = true;
      this.incidenteModel.consequencias = this.createIncidenteForm.value.consequencias;
      this.incidenteModel.descricao = this.createIncidenteForm.value.descricao;
      this.incidenteModel.divulgadoExternamente = false;
      this.incidenteModel.divulgadoInternamente = false;
      this.incidenteModel.titulo = this.createIncidenteForm.value.titulo;
      this.incidenteModel.prioridade = this.createIncidenteForm.value.prioridade;
      this.incidenteModel.insumoId = this.createIncidenteForm.value.insumoId.insumoId;
      this.incidenteModel.setorId = this.createIncidenteForm.value.setorId.insumoId;
      this.incidenteModel.statusId = this.createIncidenteForm.value.statusId.insumoId;
      this.incidenteModel.tipoOcorrenciaId = this.createIncidenteForm.value.tipoOcorrenciaId.insumoId;

      this.incidentesService.createIncidente(this.incidenteModel)
      .subscribe(
        result => { this.onSaveComplete(result) },
        fail => { this.onError(fail) }
      ); 

        
    }
  }

  onSaveComplete(response: any): void {
    this.errors = [];
    this.presentToast("Criado com sucesso!", 1000).then(() => {
      setTimeout(() => {
        this.modalController.dismiss(this.incidenteModel);
      });
    });

  }

  onError(fail: any) {
    this.dismissLoading()
    this.presentToast("Ocorreu um erro.", 2000)
    this.errors = fail.error.errors;
  }

  async presentLoading() {
    this.isLoading = true;
    await this.loadingController.create({
    }).then(a => {
      a.present().then(() => {
        if (!this.isLoading) {
          a.dismiss();
        }
      });
    });
  }

  async dismissLoading() {
    this.isLoading = false;
    await this.loadingController.dismiss();
  }

  async presentToast(message: string, duration: number) {
    const toast = await this.toastController.create({
      message: message,
      duration: duration
    });
    toast.present();
  }
}
