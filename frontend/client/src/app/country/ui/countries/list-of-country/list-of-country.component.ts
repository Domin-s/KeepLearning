import { Component, Input, OnInit, Output, inject } from '@angular/core';
import { Country } from '../../../models/Country';
import { CountryService } from '../../../services/country.service';
import { RouterLink } from '@angular/router';
import { TableOfCountriesComponent } from '../table-of-country/table-of-country.component';
import { ContinentsCheckboxComponent } from '../../../shared/continents/continents-checkbox/continents-checkbox.component';
import { Checkbox } from '../../../../common/checkbox/model/checkbox';
import { Continent } from '../../../models/Continent';
import { ContinentMapper } from '../../../mappers/continent.mapper';

@Component({
  standalone: true,
  selector: 'app-list-of-countries',
  templateUrl: './list-of-country.component.html',
  styleUrl: './list-of-country.component.scss',
  imports: [
    TableOfCountriesComponent,
    ContinentsCheckboxComponent,
    RouterLink
  ]
})
export class ListOfCountriesComponent implements OnInit {
  @Output() countries: Country[] = [];
  @Input() continentsCheckbox: Checkbox[] = [];

  private countryService: CountryService = inject(CountryService);
  public continents: string[] = ['Africa', 'Asia', 'Australia', 'Europe', 'North America', 'South America'];

  ngOnInit(): void {
    this.getCountries();
  }

  goToCreatorToGenerateRandomQuestion(){
    console.log("ListOfCountriesComponent => goToCreatorToGenerateRandomQuestion");
  }

  getCountries() {
    this.countryService.getCountries().subscribe({
      next: (result) => {
        this.countries = result;
      },
      error: (error) => {
        this.countries = [];
        console.log(error);
      }
    })
  }

  updateCheckedContinents(checkboxes: Checkbox[]) {
    this.continentsCheckbox = checkboxes;
    this.setContinentsToParam();
  }

  setContinentsToParam() {
    console.log("setContinentsToParam");
    console.log(this.continentsCheckbox);
    let checkedContinents = this.continentsCheckbox.filter(c => c.isChecked);
    this.continents = checkedContinents.map( c => c.value);
    console.log(this.continents);
  }
}
