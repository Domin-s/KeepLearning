import { HttpClient } from "@angular/common/http";
import { Injectable, inject } from "@angular/core";
import { GenerateExamForm } from "../forms/generateExam.form";
import { Exam } from "../models/Exam";

@Injectable({
  providedIn: "root",
})
export class ExamService {
  private URL = "https://localhost:5001/api/country/exam";

  private http: HttpClient = inject(HttpClient);

  getCategories() {
    return this.http.get<string[]>(this.URL + '/category');
  }

  generateExam(generateExamForm: GenerateExamForm) {
    return this.http.post<Exam>(this.URL + '/generate', generateExamForm);
  }
}