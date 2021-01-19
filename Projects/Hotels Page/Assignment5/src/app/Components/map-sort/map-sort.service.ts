import { Injectable } from '@angular/core';
import { IEntry } from 'src/app/app.model';
import * as Hotels from 'src/Data/data.json';

@Injectable({
  providedIn: 'root'
})
export class MapSortService {

  constructor() { }

  GetMapUrl(): string {
    return Hotels[1].entries[0].mapurl;
  }

  FillSortingFilters(): string[] {
    return Hotels[1].entries[0].filters.map(e => e.name);
  }

  SortByFilter(sortingFilter: string): IEntry[] {
    //if entry.filter.name = sortingFilter it goes up else it goes down
    return Hotels[1].entries.sort(e => e.filters.some(f => f.name === sortingFilter) ? -1 : 1);
  }
}