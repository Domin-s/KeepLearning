import { Component, Input } from '@angular/core';
import { Country } from '../../models/Country';

@Component({
  selector: 'app-table-of-countries',
  templateUrl: './table-of-countries.component.html',
  styleUrl: './table-of-countries.component.css'
})
export class TableOfCountriesComponent {
  @Input({required: true}) countries: Country[] = [];
}
