import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FilmComponent } from './film/film.component';
import { ShowFilmComponent } from './film/show-film/show-film.component';
import { AddEditFilmComponent } from './film/add-edit-film/add-edit-film.component';
import { KorisnikComponent } from './korisnik/korisnik.component';
import { ShowKorisnikComponent } from './korisnik/show-korisnik/show-korisnik.component';
import { AddEditKorisnikComponent } from './korisnik/add-edit-korisnik/add-edit-korisnik.component';
import { SharedService } from './shared.service';

import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    FilmComponent,
    ShowFilmComponent,
    AddEditFilmComponent,
    KorisnikComponent,
    ShowKorisnikComponent,
    AddEditKorisnikComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [SharedService],
  bootstrap: [AppComponent],
})
export class AppModule {}
