import { Component, OnInit, Output, inject } from '@angular/core';
import { Country } from '../../../models/Country';
import { CountryService } from '../../../services/country.service';
import { ContinentsCheckboxComponent } from '../../continents/continents-checkbox/continents-checkbox.component';
import { RouterLink } from '@angular/router';
import { TableOfCountriesComponent } from '../table-of-country/table-of-country.component';

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

  private countryService: CountryService = inject(CountryService);

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
}
