import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable, inject } from "@angular/core";
import { Country } from "../models/Country";

@Injectable({
  providedIn: "root",
})
export class CountryService {
  private URL = "https://localhost:5001/api/country";

  private http: HttpClient = inject(HttpClient);

  getCountries(continents: string[], pageNumber?: number, pageSize?: number) {
    let params = this.createGetCountryParams(continents, pageNumber, pageSize);
    return this.http.get(this.URL, {params, observe: 'response'});
  }

  createGetCountryParams(continents: string[], pageNumber?: number, pageSize?: number): HttpParams {
    let params = new HttpParams();

    for (let index = 0; index < continents.length; index++) {
      params = params.append("Continents", continents[index]);
    }

    if(pageNumber !== undefined) {
      params.append("PageNumber", pageNumber);
    }

    if(pageSize !== undefined) {
      params.append("PageSize", pageSize);
    }

    return params;
  }
}