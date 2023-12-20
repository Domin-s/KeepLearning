import { Component, Input } from '@angular/core';
import { Country } from '../../../models/Country';

@Component({
  standalone: true,
  selector: 'app-table-of-countries',
  templateUrl: './table-of-country.component.html',
  styleUrl: './table-of-country.component.scss',
})
export class TableOfCountriesComponent {
  @Input({required: true}) countries: Country[] = [];
}
