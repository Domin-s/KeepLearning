import { HttpClient } from '@angular/common/http';
import { Component, OnInit, Output } from '@angular/core';
import { Country } from '../../models/Country';
import { TableOfCountriesComponent } from '../table-of-countries/table-of-countries.component';

@Component({
  standalone: true,
  selector: 'app-list-of-countries',
  templateUrl: './list-of-countries.component.html',
  styleUrl: './list-of-countries.component.scss',
  imports: [TableOfCountriesComponent]
})
export class ListOfCountriesComponent implements OnInit {
  @Output() countries: Country[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getCountries();
  }
  
  goToCreatorToGenerateExam() {
    console.log("ListOfCountriesComponent => goToCreatorToGenerateExam");
  }

  goToCreatorToGenerateRandomQuestion(){
    console.log("ListOfCountriesComponent => goToCreatorToGenerateRandomQuestion");
  }

  getCountries() {
    this.http.get<Country[]>('/country').subscribe(
      (result) => {
        this.countries = result;
      },
      (error) => {
        console.log(error);
      }
    )
  }
}
