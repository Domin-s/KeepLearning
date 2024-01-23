import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { CountryService } from '../../../../services/country.service';
import { Country } from '../../../../models/Country';

@Component({
  standalone: true,
  selector: 'app-country-table-component',
  templateUrl: './country-table.component.html',
  styleUrl: './country-table.component.scss',
})
export class CountryTableComponent implements OnInit, OnChanges {
  @Input({required: true}) continentsChecked: string[] = [];
  @Input({required: true}) pageNumber!: number;
  @Input({required: true}) pageSize!: number;

  public countries: Country[] = [];


  constructor(
    private countryService: CountryService,
  ){}

  ngOnInit(): void {
    this.getCountries();
  }
  
  ngOnChanges(changes: SimpleChanges): void {
    if (!changes['continentsChecked'].isFirstChange()) {
      this.getCountries();
    }
  }
  
  fiterCountriesByCheckedContientns(): Country[] {
    return this.countries.filter(c => this.continentsChecked.includes(c.continentDto.name));;
  }
  

  getCountries() {
    this.countryService.getCountries(this.continentsChecked, this.pageNumber, this.pageSize).subscribe({
      next: (result) => {
        this.countries = result;
      },
      error: (error) => {
        console.log(error);
      }
    })
  }
}
