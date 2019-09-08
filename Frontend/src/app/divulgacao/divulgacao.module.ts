import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import { IonicModule } from '@ionic/angular';

import { DivulgacaoPage } from './divulgacao.page';

import { ErrorInterceptor } from '../core/services/error.handler.service';
import { DivulgacaoService } from './services/divulgacao.services';
import { GridModule } from '@progress/kendo-angular-grid';
const routes: Routes = [
  {
    path: '',
    component: DivulgacaoPage
  }
];

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    GridModule,
    HttpClientModule,
    RouterModule.forChild(routes)
  ],
  declarations: [DivulgacaoPage],
  providers: [
    DivulgacaoService,    
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorInterceptor,
      multi: true
  }]
})
export class DivulgacaoPageModule {}
