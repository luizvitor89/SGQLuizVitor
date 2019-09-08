import { Component, OnInit, ViewChildren, ElementRef } from '@angular/core';
import { ToastController, LoadingController, ModalController } from '@ionic/angular';

import { FormBuilder, FormGroup, Validators, FormControlName, FormControl } from '@angular/forms';

import { Router } from "@angular/router";

import { LoginService } from "./services/login.services";
import { LoginModel } from "./models/loginModel";

@Component({
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss'],
})
export class LoginPage implements OnInit {

  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];
  public loginForm: FormGroup;
  public loginModel: LoginModel;

  public isLoading = false;


  constructor(private formBuilder: FormBuilder,
    private loginService: LoginService,
    private router: Router,
    public toastController: ToastController,
    public loadingController: LoadingController,
    public modalController: ModalController) {

  }

  ngOnInit() {
    
    let loginInfo = JSON.parse(localStorage.getItem('sgq.login'));
    this.loginModel = loginInfo != null && (loginInfo.loginModel != undefined && loginInfo.loginModel != null) ? loginInfo.loginModel: new LoginModel();

    this.loginForm = this.formBuilder.group({
      email: new FormControl(this.loginModel.email, Validators.compose([
        Validators.required,
        Validators.pattern('^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$')
      ])),
      senha: [this.loginModel.senha, [Validators.required]]
    });
  }

  validation_messages = {
    'email': [
      { type: 'required', message: 'O email é requerido' },
      { type: 'pattern', message: 'Favor informar um email válido' }
    ],
    'senha': [
      { type: 'required', message: 'A senha é requerida' }
    ]
  };

  login() {
    if (this.loginForm.valid) {
      this.loginModel.email = this.loginForm.value.email;
      this.loginModel.senha = this.loginForm.value.senha;
      
      localStorage.setItem('sgq.login', JSON.stringify({loginModel: this.loginModel }));

      this.presentLoading();
      this.loginService.login(this.loginModel)
        .subscribe(
          result => { this.dismissLoading(); this.onSaveComplete(result) },
          fail => { this.dismissLoading(); this.onError(fail) }
        );          
    }
  }

  onSaveComplete(response: any): void {
    localStorage.setItem('sgq.token', response.token);
    localStorage.setItem('sgq.user', JSON.stringify(response));
 
    this.presentToast('Login efetuado com sucesso!', 1000).then(() => {
      setTimeout(() => {
        this.router.navigate(['/home']);
      });
    });

  }

  onError(fail: any) {
    this.presentToast('Erro ao efetuar o login', 2000)
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
}
