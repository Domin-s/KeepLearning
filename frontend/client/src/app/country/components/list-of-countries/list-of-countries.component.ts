import { HttpClient } from '@angular/common/http';
import { Component, OnInit, Output, inject } from '@angular/core';
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
  private URL = "https://localhost:5001/api/Country";

  countries: Country[] = [];

  private http: HttpClient = inject(HttpClient);

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
    console.log("ListOfCountriesComponent => ListOfCountriesComponent");
    this.http.get<Country[]>("https://localhost:5001/api/Country").subscribe({
      next: (result) => {
        console.log(result);
        this.countries = result;
      },
      error: (error) => {
        console.log(error);
      }
  })
  }
}
