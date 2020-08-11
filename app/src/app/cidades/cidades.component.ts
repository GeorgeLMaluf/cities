import { Component, TemplateRef, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Cidade } from 'src/app/Models/cidade';
import { CidadeService } from 'src/app/Services/cidade.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-cidades',
  templateUrl: './cidades.component.html',
  styleUrls: ['./cidades.component.css']
})
export class CidadesComponent implements OnInit {

  modalRef: BsModalRef;
  isLoading: boolean;
  cidades: Cidade[];
  cidadeToDelete: any;

  constructor(
    private cidadesrv: CidadeService,
    private modalService: BsModalService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.loadCidades();
  }

  private loadCidades() {
    this.isLoading = true;
    this.cidadesrv.getAll()
      .subscribe(response => {
        this.isLoading = false;
        this.cidades = response;
      });
  }

  openModal(template: TemplateRef<any>, data) {
    this.cidadeToDelete = data;
    this.modalRef = this.modalService.show(template, this.cidadeToDelete);
  }

  deleteCity(id) {
    this.cidadesrv.removeById(id)
      .subscribe(
         response => {
            this.loadCidades();
      });
  }

  editar(id) {
    this.router.navigate(['editar', id], {relativeTo: this.route });
  }

  decline(): void {
    this.modalRef.hide();
  }

  confirmDelete(data): void {
    this.deleteCity(data.id);
    this.modalRef.hide();
  }
}
