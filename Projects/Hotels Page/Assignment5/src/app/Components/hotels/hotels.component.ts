import { Component, Input } from '@angular/core';
import { IEntry } from 'src/app/app.model';
import {Methods} from 'src/Shared/shared';

@Component({
  selector: 'app-hotels',
  templateUrl: './hotels.component.html',
  styleUrls: ['./hotels.component.css']
})
export class HotelsComponent {
  @Input() entries: IEntry[];

  constructor() { }

  Stars(n?: number): number[] {
    return Methods.FixedArray(n);
  }
}