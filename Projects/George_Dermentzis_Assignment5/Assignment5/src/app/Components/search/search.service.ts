import { Injectable } from '@angular/core';
import { IEntry } from 'src/app/app.model';
import * as Hotels from 'src/Data/data.json';

@Injectable({
  providedIn: 'root'
})
export class SearchService {
  constructor() { }

  //Search each hotel entry by city (all lowercase)
  //return filtered entries as Output to parent component
  //filter cities for the autocomplete options
  //so that i don't have duplicate values on the html but send the right entries back to parent component
  FilterByCity(search: string, cities: string[]): IEntry[] {
    cities.length = 0;

    return Hotels[1].entries.filter(function (e) {
      let cityToLower = e.city.toLowerCase();
      let exists = cityToLower.includes(search.toLowerCase());  
      if (cities.indexOf(cityToLower) === -1 && exists) {
        cities.push(cityToLower);
      }

      return exists;
    });
  }
}