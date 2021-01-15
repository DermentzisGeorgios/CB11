import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { IEntry } from 'src/app/app.model';
import * as Hotels from 'src/Data/data.json';
import { FilterService } from './filter.service';
import { Ratings } from './custom-ratings';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.css']
})
export class FilterComponent implements OnInit {
  entries: IEntry[];
  @Output() entriesChange = new EventEmitter<IEntry[]>();

  selectedPrice: number;
  selectedRating: number;
  customRatings: Ratings[];
  selectedRatings: Ratings;
  cities: string[];
  selectedCity: string;

  constructor(private filterService: FilterService) { }

  ngOnInit(): void {
    this.selectedPrice = 1500;
    this.customRatings = this.filterService.FillCustomRatings();
    this.cities = this.filterService.FillCities();
  }

  EntriesChange() {
    return this.entriesChange.emit(this.entries);
  }

  FilterEntriesByPrice(): void {
    this.entries = this.selectedPrice ? this.filterService.FilterByPrice(this.selectedPrice) : Hotels[1].entries;
    this.EntriesChange();
  }

  FilterEntriesByRating(): void {
    this.entries = this.selectedRating ? this.filterService.FilterByRating(this.selectedRating) : Hotels[1].entries;
    this.EntriesChange();
  }

  FilterEntriesByRatings(): void {
    this.entries = this.selectedRatings ? this.filterService.FilterByRatings(this.selectedRatings) : Hotels[1].entries;
    this.EntriesChange();
  }

  FilterEntriesByLocation(): void {
    this.entries = this.selectedCity ? this.filterService.FilterByCity(this.selectedCity) : Hotels[1].entries;
    this.EntriesChange();
  }
}