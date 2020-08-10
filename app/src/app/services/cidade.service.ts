import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Cidade } from '../models/cidade';
@Injectable({
  providedIn: 'root'
})
export class CidadeService {

  private headers = new HttpHeaders({
    'Content-type': 'application/json'
  });

  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<Cidade[]>(`${environment.apiUrl}/cities`, {headers: this.headers });
  }
}
