import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CidadeComponent } from './cidade/cidade.component';
import { CidadeListComponent } from './cidade/cidade-list/cidade-list.component';

const routes: Routes = [
  {path: '', component: CidadeComponent,
    children: [
      { path: 'cidades', component: CidadeListComponent}
    ]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
