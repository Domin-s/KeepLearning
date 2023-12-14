import { Component, Input } from '@angular/core';
import { Country } from '../../models/Country';

@Component({
  selector: 'app-row-country',
  templateUrl: './row-country.component.html',
  styleUrl: './row-country.component.scss'
})
export class RowCountryComponent {
  @Input({ required: true }) country!: Country;
}
