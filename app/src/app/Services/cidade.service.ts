import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Cidade } from '../Models/cidade';
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

  getById(id) {
    return this.http.get<Cidade>(`${environment.apiUrl}/cities/${id}`, { headers: this.headers});
  }

  getByPattern(pattern) {
    return this.http.get<Cidade[]>(`${environment.apiUrl}/cities/${pattern}`, {headers: this.headers});
  }

  removeById(id) {
    return this.http.delete(`${environment.apiUrl}/cities/${id}`, {headers : this.headers});
  }

  addCity(value) {
    return this.http.post(`${environment.apiUrl}/cities`, JSON.stringify(value), {headers: this.headers});
  }

  updateCity(value) {
    return this.http.put(`${environment.apiUrl}/cities/${value.Id}`, JSON.stringify(value), {headers: this.headers});
  }
}
