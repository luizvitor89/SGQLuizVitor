import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';
import { IncidentesService } from './services/incidentes.services';
import { ToastController, LoadingController, ModalController } from '@ionic/angular';
import { IncidenteModel } from "./models/incidenteModel";
import { NewIncidenteModalComponent } from './modals/new-incidente-modal/new-incidente-modal.component';
@Component({
  selector: 'app-incidentes',
  templateUrl: './incidentes.page.html',
  styleUrls: ['./incidentes.page.scss'],
})
export class IncidentesPage implements OnInit {

  public menuSegment: string = "incidentes";
  public isLoading = false;

  public gridData: any[];
  
  constructor(private router: Router,
    private incidentesService: IncidentesService,
    public toastController: ToastController,
    public loadingController: LoadingController,
    public modalController: ModalController
    ) {}

  ngOnInit() {
    this.changeSegment(this.menuSegment);

    this.presentLoading();
      this.incidentesService.getIncidentes()
        .subscribe(
          result => { this.dismissLoading(); this.onGetComplete(result) },
          fail => { this.dismissLoading(); this.onError(fail) }
        );  
  }

  onGetComplete(response: IncidenteModel[]): void {
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

  async presentNewIncidenteModal() {
    const modal = await this.modalController.create({
      component: NewIncidenteModalComponent
    });

    modal.onDidDismiss().then((r) => {

      let incidenteModel: IncidenteModel;
      if (r != undefined) {
        incidenteModel = r['data'];

        this.gridData.push(incidenteModel);
      }

    });

    return await modal.present();
  }
}
