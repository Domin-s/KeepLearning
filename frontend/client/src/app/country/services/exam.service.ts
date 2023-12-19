import { HttpClient } from "@angular/common/http";
import { Injectable, inject } from "@angular/core";

@Injectable({
  providedIn: "root",
})
export class ExamService {
  private URL = "https://localhost:5001/api/country/exam";

  private http: HttpClient = inject(HttpClient);

  getCategories() {
    return this.http.get<string[]>(this.URL + '/category');
  }
}