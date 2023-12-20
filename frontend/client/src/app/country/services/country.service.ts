import { HttpClient } from "@angular/common/http";
import { Injectable, inject } from "@angular/core";
import { Country } from "../models/Country";

@Injectable({
    providedIn: "root",
  })
  export class CountryService {
    private URL = "https://localhost:5001/api/country";

    private http: HttpClient = inject(HttpClient);

  getCountries() {
    return this.http.get<Country[]>(this.URL);
  }
}