import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { Country } from '../../../models/Country';

@Component({
  standalone: true,
  selector: 'app-country-table-component',
  templateUrl: './country-table.component.html',
  styleUrl: './country-table.component.scss',
})
export class CountryTableComponent implements OnInit, OnChanges {
  @Input({required: true}) countries: Country[] = [];
  @Input({required: true}) continentsChecked: string[] = [];

  public filteredCountries: Country[] = [];

  ngOnInit(): void {
    this.filteredCountries = this.countries;
  }
  
  ngOnChanges(changes: SimpleChanges): void {
    if (!changes['continentsChecked'].isFirstChange()) {
      this.filteredCountries = this.fiterCountriesByCheckedContientns();
    }
  }

  fiterCountriesByCheckedContientns(): Country[] {
    return this.countries.filter(c => this.continentsChecked.includes(c.continentDto.name));;
  }
}
