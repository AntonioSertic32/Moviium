import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { KorisnikComponent } from './korisnik/korisnik.component';
import { FilmComponent } from './film/film.component';

const routes: Routes = [
  { path: 'korisnik', component: KorisnikComponent },
  { path: 'film', component: FilmComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
