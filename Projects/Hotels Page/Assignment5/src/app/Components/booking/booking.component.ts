import { Component, OnInit } from '@angular/core';
import { Moment } from 'moment';
import { IRoomtype } from 'src/app/app.model';
import * as Hotels from 'src/Data/data.json';

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.css']
})
export class BookingComponent implements OnInit {
  checkInDate: Moment;
  roomTypes: IRoomtype[];

  constructor() { }

  ngOnInit(): void {
    this.roomTypes = Hotels[0].roomtypes;
  }
}