import { Component, Output, EventEmitter } from '@angular/core';
import { IEntry } from 'src/app/app.model';
import { SearchService } from './search.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent {
  search: string = "";
  cities: string[] = [];
  entries: IEntry[];
  @Output() citiesChange = new EventEmitter<IEntry[]>();

  constructor(private searchService: SearchService) { }

  CitiesChange() {
    this.SearchFilter();
    return this.citiesChange.emit(this.entries);
  }

  SearchFilter(): void {
    this.entries = this.searchService.FilterByCity(this.search, this.cities);
  }
}