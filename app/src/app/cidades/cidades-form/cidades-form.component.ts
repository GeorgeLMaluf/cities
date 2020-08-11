import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { switchMap, map } from 'rxjs/operators';
import { CidadeService } from 'src/app/Services/cidade.service';


@Component({
  selector: 'app-cidades-form',
  templateUrl: './cidades-form.component.html',
  styleUrls: ['./cidades-form.component.css']
})
export class CidadesFormComponent implements OnInit {
  CidadeForm: FormGroup;
  titulo: string;

  editMode: boolean;
  insertMode: boolean;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private cidadeSrv: CidadeService,
  ) { }

  ngOnInit(): void {
    this.editMode = false;
    this.titulo = "Nova Cidade";
    if (this.route.snapshot.params.id) {
      this.titulo = "Editar Cidade";
      this.editMode = true;
      this.route.params
        .pipe(
          map((params:any) => params.id),
          switchMap(id => this.cidadeSrv.getById(id))
        )
        .subscribe(city => this.updateForm(city));
    }
    this.insertMode = !this.editMode;
    this.CidadeForm = this.fb.group ({
      Id: [null],
      Ibge: [null, Validators.required],
      Cidade: [null, Validators.required],
      Uf: [null, Validators.required],
      Regiao: [null, Validators.required],
      Longitude: [null, Validators.required],
      Latitude: [null,Validators.required]
    });

  }

  updateForm(cidade) {
    this.CidadeForm.patchValue({
      Id: cidade.id,
      Ibge: cidade.ibge,
      Cidade: cidade.cidade,
      Uf: cidade.uf,
      Regiao: cidade.regiao,
      Longitude: cidade.longitude,
      Latitude: cidade.latitude
    });
  }

  onSubmit(){
    if (this.CidadeForm.value.Id) {
      this.cidadeSrv.updateCity(this.CidadeForm.value)
        .subscribe(
          res => {
            this.router.navigate(['/cidades']);
          }
        );
    }
    else
    {
      this.cidadeSrv.addCity(this.CidadeForm.value)
        .subscribe(
          res => {
            this.router.navigate(['/cidades']);
          }
        );
    }
  }

}
