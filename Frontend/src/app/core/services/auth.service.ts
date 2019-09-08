import { Injectable } from "@angular/core";
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from "@angular/router";
import { ToastController } from '@ionic/angular';

@Injectable()
export class AuthService implements CanActivate {
    public token: string;
    public user;

    constructor(private router: Router,
                public toastController: ToastController) { }

    canActivate(routeAc: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        this.token = localStorage.getItem('sgq.token');
        this.user = JSON.parse(localStorage.getItem('sgq.user'));

        if (!this.token) {
            this.presentToast('Você precisa estar autenticado para acessar esta pagina!', 2000)
            this.router.navigate(['/login'])
            return false;
        }

        let claim: any = routeAc.data[0];

        if (claim !== undefined) {
            let claim = routeAc.data[0]['claim'];
            if (claim) {
                if (!this.user.claims) {
                    this.presentToast('Você não tem permissão para acessar esta pagina!', 2000)
                    this.router.navigate(['/home']);
                    return false;
                }
                let userClaims = this.user.claims.some(x => x.funcionalidade === claim.nome && x.permissao === claim.valor);
                if (!userClaims) {
                    this.presentToast('Você não tem permissão para acessar esta pagina!', 2000)
                    this.router.navigate(['/home']);
                    return false;
                }
            }
        }
        return true;
    }

    async presentToast(message: string, duration: number) {
        const toast = await this.toastController.create({
          message: message,
          duration: duration
        });
        toast.present();
      }
}