import { Component, OnInit, Output } from '@angular/core';
import { Country } from '../../../models/Country';
import { CountryService } from '../../../services/country.service';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { ContinentsCheckboxComponent } from '../../../shared/continents/continents-checkbox/continents-checkbox.component';
import { CountryTableComponent } from '../../../shared/country/country-table/country-table.component';
import { PreviousRouteService } from '../../../services/previousRoute.service';
import { GenerateExamForm } from '../../../forms/generateExam.form';

@Component({
  standalone: true,
  selector: 'app-list-of-countries',
  templateUrl: './list-of-country.component.html',
  styleUrl: './list-of-country.component.scss',
  imports: [
    CountryTableComponent,
    ContinentsCheckboxComponent,
    RouterLink
  ],
  providers: [GenerateExamForm],
})
export class ListOfCountriesComponent implements OnInit {
  @Output() countries: Country[] = [];

  previousUrl: string = '';
  currentUrl: string = '';

  public continentsChecked: string[] = ['Africa', 'Asia', 'Australia', 'Europe', 'North America', 'South America'];

  constructor(
    private countryService: CountryService,
    private route: ActivatedRoute,
    private previousRouteService: PreviousRouteService
  ) {
  }
  
  ngOnInit(): void {
    this.previousUrl = this.previousRouteService.getPreviousUrl();
    this.continentsChecked = this.setCheckedContinentByDefault()
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
      continentsFromPath = params.getAll('continentsChecked');
    });

    return continentsFromPath;
  }

  setCheckedContinentByDefault(): string[]{
    if (this.previousUrl.includes('/country/generateExam')) {
      return this.getContinentsFromPath();
    }

    return this.continentsChecked;
  }
}
