import { Injectable } from '@angular/core';
import {Ratings} from './custom-ratings';
import * as Hotels from 'src/Data/data.json';
import { IEntry } from 'src/app/app.model';

@Injectable({
  providedIn: 'root'
})
export class FilterService {

  constructor() { }

  FillCustomRatings(): Ratings[] {
    return [
      new Ratings(0, 2, "Okay"),
      new Ratings(2, 6, "Fair"),
      new Ratings(6, 7, "Good"),
      new Ratings(7, 8.5, "Very Good"),
      new Ratings(8.5, 10, "Excellent")
    ]
  }

  FillCities(): string[] {
    let cities: string[] = [];
    Hotels[1].entries.forEach(function(entry){
      if (cities.indexOf(entry.city) === -1) {
        cities.push(entry.city);
      }
    });

    return cities;
  }

  FilterByPrice(selectedPrice: number): IEntry[] {
    return Hotels[1].entries.filter(entry => entry.price <= selectedPrice);
  }

  FilterByRating(selectedRating: number): IEntry[] {
    return Hotels[1].entries.filter(entry => entry.rating === selectedRating);
  }

  FilterByRatings(selectedRatings: Ratings): IEntry[] {
    return Hotels[1].entries.filter(entry => selectedRatings.min < entry.ratings.no && entry.ratings.no < selectedRatings.max);
  }

  FilterByCity(selectedCity: string): IEntry[] {
    return Hotels[1].entries.filter(entry => entry.city == selectedCity);
  }
}