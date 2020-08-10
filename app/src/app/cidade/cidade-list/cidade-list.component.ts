import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Cidade } from 'src/app/models/cidade';
import { CidadeService } from 'src/app/services/cidade.service';

@Component({
  selector: 'app-cidade-list',
  templateUrl: './cidade-list.component.html',
  styleUrls: ['./cidade-list.component.scss']
})
export class CidadeListComponent implements OnInit {
  cidades: Cidade[];


  constructor(
    private cidadesrv: CidadeService
  ) { }

  ngOnInit(): void {
    this.loadCidades();
  }

  private loadCidades() {
    this.cidadesrv.getAll()
      .subscribe(response => {
        this.cidades = response;
      });
  }
}
