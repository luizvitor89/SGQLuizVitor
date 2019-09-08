import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';

import { IonicModule } from '@ionic/angular';

import { IncidentesPage } from './incidentes.page';
import { ErrorInterceptor } from '../core/services/error.handler.service';
import { IncidentesService } from './services/incidentes.services';
import { GridModule } from '@progress/kendo-angular-grid';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { NewIncidenteModalComponent } from './modals/new-incidente-modal/new-incidente-modal.component';

const routes: Routes = [
  {
    path: '',
    component: IncidentesPage
  }
];

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    IonicModule,
    GridModule,
    DropDownsModule,
    HttpClientModule,
    RouterModule.forChild(routes)
  ],
  declarations: [IncidentesPage,
    NewIncidenteModalComponent],
  providers: [
    IncidentesService,    
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorInterceptor,
      multi: true
  },
  ],
  entryComponents: [
    NewIncidenteModalComponent
  ]
})
export class IncidentesPageModule {}
