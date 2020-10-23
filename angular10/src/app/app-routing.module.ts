import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { KorisnikComponent } from './korisnik/korisnik.component';
import { FilmComponent } from './film/film.component';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
  { path: 'korisnik', component: KorisnikComponent },
  { path: 'film', component: FilmComponent },
  { path: 'login', component: LoginComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
