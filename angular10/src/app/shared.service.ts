import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SharedService {
  readonly APIUrl = 'https://localhost:5001/api';

  constructor(private http: HttpClient) {}

  getFilmList(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + '/Movies/GetMovies');
  }

  addFilm(val: any) {
    return this.http.post(this.APIUrl + '/movies', val);
  }

  updateFilm(val: any) {
    return this.http.put(this.APIUrl + '/movies', val);
  }

  deleteFilm(val: any) {
    return this.http.delete(this.APIUrl + '/movies' + val);
  }

  getKorisnikList(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + '/Korisnik');
  }

  addKorisnik(val: any) {
    return this.http.post(this.APIUrl + '/Korisnik', val);
  }

  updateKorisnik(val: any) {
    return this.http.put(this.APIUrl + '/Korisnik', val);
  }

  deleteKorisnik(val: any) {
    return this.http.delete(this.APIUrl + '/Korisnik' + val);
  }
}
