import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { IonicModule } from '@ionic/angular';

import { HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';

import { LoginPage } from './login.page';

import { LoginService } from "./services/login.services";
import { SeoService } from '../core/services/seo.service';
import { ErrorInterceptor } from '../core/services/error.handler.service';

import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';

const routes: Routes = [
  {
    path: '',
    component: LoginPage
  }
];

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    IonicModule,
    HttpClientModule,
    ButtonsModule,
    DropDownsModule,
    RouterModule.forChild(routes)
  ],
  declarations: [
    LoginPage
  ],
  providers: [
    LoginService,
    {
        provide: HTTP_INTERCEPTORS,
        useClass: ErrorInterceptor,
        multi: true
    },
    SeoService

  ],
  entryComponents: [
  ]
})
export class LoginPageModule {}
