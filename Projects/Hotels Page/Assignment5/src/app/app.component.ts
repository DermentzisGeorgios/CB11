import { Component, OnInit } from '@angular/core';
import { IEntry, IHotel } from './app.model';
import { AppService } from './app.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Assignment5';
  hotel: IHotel;

  constructor(private service: AppService) { }

  ngOnInit(): void {
    this.hotel = this.service.GetHotels();
  }

  Filter(entries: IEntry[]): void {
    this.hotel.hotel[1].entries = entries;
  }
}