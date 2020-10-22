import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-film',
  templateUrl: './show-film.component.html',
  styleUrls: ['./show-film.component.css'],
})
export class ShowFilmComponent implements OnInit {
  constructor(private service: SharedService) {}

  FilmList: any = [];

  ngOnInit(): void {
    this.refreshFilmList();
  }

  refreshFilmList() {
    this.service.getFilmList().subscribe((data) => {
      this.FilmList = data;
    });
  }
}
