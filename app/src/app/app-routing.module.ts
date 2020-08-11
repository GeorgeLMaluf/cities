import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CidadesComponent } from './cidades/cidades.component';
import { CidadesFormComponent } from './cidades/cidades-form/cidades-form.component';

const routes: Routes = [
  { path: '',
    children : [
      { path: 'cidades', component: CidadesComponent},
      { path: 'cidades/novo', component: CidadesFormComponent },
      { path: 'cidades/editar/:id', component: CidadesFormComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
