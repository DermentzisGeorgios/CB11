import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { IEntry } from 'src/app/app.model';
import { MapSortService } from './map-sort.service';

@Component({
  selector: 'app-map-sort',
  templateUrl: './map-sort.component.html',
  styleUrls: ['./map-sort.component.css']
})
export class MapSortComponent implements OnInit {
  entries: IEntry[];
  @Output() entriesChange = new EventEmitter<IEntry[]>();

  mapUrl: string;
  sortingFilter: string;
  sortingFilters: string[];

  constructor(private sortingService: MapSortService) { }

  ngOnInit(): void {
    this.mapUrl = this.sortingService.GetMapUrl(); //passed to iframe through custom pipe
    this.sortingFilters = this.sortingService.FillSortingFilters();
  }

  EntriesChange() {
    return this.entriesChange.emit(this.entries);
  }

  SortEntriesByFilter(): void {
    this.entries = this.sortingService.SortByFilter(this.sortingFilter);
    this.EntriesChange();
  }
}