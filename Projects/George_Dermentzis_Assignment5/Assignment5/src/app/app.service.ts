import { Injectable } from '@angular/core';
import {Hotel} from 'src/Data/HotelData';

@Injectable({
  providedIn: 'root'
})
export class AppService {
  hotel: Hotel;

  constructor() {
    this.hotel = new Hotel();
   }

  GetHotels(): Hotel {
    return this.hotel;
  }
}