import { HttpClient } from '@angular/common/http';
import { Component, OnInit, Output, inject } from '@angular/core';
import { Country } from '../../models/Country';
import { TableOfCountriesComponent } from '../table-of-country/table-of-country.component';

@Component({
  standalone: true,
  selector: 'app-list-of-countries',
  templateUrl: './list-of-country.component.html',
  styleUrl: './list-of-country.component.scss',
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
