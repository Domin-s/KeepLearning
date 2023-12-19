import { HttpClient } from "@angular/common/http";
import { Injectable, inject } from "@angular/core";
import { Continent } from "../../country/models/Continent";

@Injectable({
  providedIn: "root",
})
export class ContinentService {

  private URL = 'https://localhost:5001/api/country/continent';

  private http: HttpClient = inject(HttpClient);

  getContinents() {
    return this.http.get<Continent[]>(this.URL);
  }

  getNumberOfCountries() {
    return this.http.get<number>(this.URL + '/numberOfCountries');
  }
}
