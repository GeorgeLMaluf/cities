import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { AppHeaderComponent } from './app-header/app-header.component';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { CidadeComponent } from './cidade/cidade.component';
import { CidadeListComponent } from './cidade/cidade-list/cidade-list.component';

@NgModule({
  declarations: [
    AppComponent,
    AppHeaderComponent,
    CidadeComponent,
    CidadeListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BsDropdownModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
