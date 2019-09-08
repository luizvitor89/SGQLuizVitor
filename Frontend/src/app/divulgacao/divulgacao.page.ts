import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';
import { DivulgacaoService } from './services/divulgacao.services';
import { ToastController, LoadingController, ModalController } from '@ionic/angular';
import { DivulgacaoModel } from "./models/divulgacaoModel";
import { saveAs } from 'file-saver';
@Component({
  selector: 'app-divulgacao',
  templateUrl: './divulgacao.page.html',
  styleUrls: ['./divulgacao.page.scss'],
})
export class DivulgacaoPage implements OnInit {

  public menuSegment: string = "divulgacao";
  public isLoading = false;

  public gridData: any[];
  
  constructor(private router: Router,
    private divulgacaoService: DivulgacaoService,
    public toastController: ToastController,
    public loadingController: LoadingController,
    public modalController: ModalController
    ) {}

  ngOnInit() {
    this.changeSegment(this.menuSegment);

    this.presentLoading();
      this.divulgacaoService.getDivulgacoes()
        .subscribe(
          result => { this.dismissLoading(); this.onGetComplete(result) },
          fail => { this.dismissLoading(); this.onError(fail) }
        );  
  }

  exportComunicadoExterno(){
    this.presentLoading();
      this.divulgacaoService.getComunicadoExterno()
        .subscribe(
          result => { this.dismissLoading(); this.onGetComunicadoExternoComplete(result) },
          fail => { this.dismissLoading(); this.onError(fail) }
        );  
  }

  onGetComunicadoExternoComplete(response: any[]): void {
    this.dismissLoading();
    const blob = new Blob([JSON.stringify(response)], {type : 'application/json'});
    saveAs(blob, 'comunicado.json');
  }

  onGetComplete(response: DivulgacaoModel[]): void {
    this.gridData = response;
    this.dismissLoading();
  }

  onError(fail: any) {
    this.presentToast('Erro ao efetuar a consulta', 2000)
  }

  async presentToast(message: string, duration: number) {
    const toast = await this.toastController.create({
      message: message,
      duration: duration
    });
    toast.present();
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

  changeSegment(segment: string) {
    this.menuSegment = segment;
  }

  navigate(route: string) {
    this.changeSegment(route);
    this.router.navigateByUrl('/'+ route);
  }

  sair() {
    localStorage.removeItem('sgq.token');
    this.router.navigateByUrl('/login');
  }
}
