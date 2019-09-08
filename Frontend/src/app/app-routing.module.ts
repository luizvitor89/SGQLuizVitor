import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

import { HomePageModule } from './home/home.module';
import { LoginPageModule } from './login/login.module';
import { IncidentesPageModule } from './incidentes/incidentes.module';

import { AuthService } from "./core/services/auth.service";


const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'login', loadChildren: () => LoginPageModule },
  { path: 'home', loadChildren: () => HomePageModule, canActivate: [AuthService], data: [{ claim: { nome: 'CIP', valor: 'Visualizar' }}] },
  { path: 'incidentes', loadChildren: () => IncidentesPageModule, canActivate: [AuthService], data: [{ claim: { nome: 'CIP', valor: 'Visualizar' }}] },
  { path: 'divulgacao', loadChildren: './divulgacao/divulgacao.module#DivulgacaoPageModule' },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
