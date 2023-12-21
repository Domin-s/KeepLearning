import { Component, Input } from '@angular/core';
import { Country } from '../../../models/Country';

@Component({
  standalone: true,
  selector: 'app-country-table-component',
  templateUrl: './country-table.component.html',
  styleUrl: './country-table.component.scss',
})
export class CountryTableComponent {
  @Input({required: true}) countries: Country[] = [];
}
