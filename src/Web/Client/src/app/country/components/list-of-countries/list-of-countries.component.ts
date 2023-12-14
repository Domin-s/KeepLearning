import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Country } from '../../models/Country';

@Component({
  selector: 'app-list-of-countries',
  templateUrl: './list-of-countries.component.html',
  styleUrl: './list-of-countries.component.scss'
})
export class ListOfCountriesComponent implements OnInit {
  public countries: Country[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getCountries();
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
