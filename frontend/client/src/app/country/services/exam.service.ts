import { HttpClient } from "@angular/common/http";
import { Injectable, inject } from "@angular/core";

@Injectable({
    providedIn: "root",
  })
  export class ExamService {
    private URL = "https://localhost:5001/api/country/exam/category";

    private http: HttpClient = inject(HttpClient);

  getCountries() {
    return this.http.get<string[]>(this.URL);
  }
}