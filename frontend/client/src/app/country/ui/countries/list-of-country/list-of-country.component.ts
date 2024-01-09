import { Component, OnInit, Output } from '@angular/core';
import { Country } from '../../../models/Country';
import { CountryService } from '../../../services/country.service';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { ContinentsCheckboxComponent } from '../../../shared/continents/continents-checkbox/continents-checkbox.component';
import { CountryTableComponent } from '../../../shared/country/country-table/country-table.component';
import { ContinentCheckbox } from '../../../services/ContinentCheckbox';

@Component({
  standalone: true,
  selector: 'app-list-of-countries',
  templateUrl: './list-of-country.component.html',
  styleUrl: './list-of-country.component.scss',
  imports: [
    CountryTableComponent,
    ContinentsCheckboxComponent,
    RouterLink
  ]
})
export class ListOfCountriesComponent implements OnInit {
  @Output() countries: Country[] = [];

  public continentsChecked: string[] = [];

  constructor(
    private countryService: CountryService,
    private route: ActivatedRoute
  ) {
  }
  
  ngOnInit(): void {
    this.continentsChecked = this.getContinentsFromPath();
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

  getCheckedContinents(continents: string[]){
    this.continentsChecked = continents;
  }

  getContinentsFromPath(){
    let continentsFromPath: string[] = []; 
    
    this.route.queryParamMap.subscribe( params => {
      continentsFromPath = params.getAll('continents');
    });

    return continentsFromPath;
  }
}
