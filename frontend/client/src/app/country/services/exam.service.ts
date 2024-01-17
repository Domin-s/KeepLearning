import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable, inject } from "@angular/core";
import { Exam } from "../models/Exam";
import { FormGroup } from "@angular/forms";
import { Category } from "../models/Category";

@Injectable({
  providedIn: "root",
})
export class ExamService {
  private URL = "https://localhost:5001/api/country/exam";

  constructor(private http: HttpClient) {}

  getCategories() {
    return this.http.get<Category[]>(this.URL + '/category');
  }

  generateExam(generateExamForm: FormGroup) {
    let formObj = generateExamForm.value;
    let serializedForm = JSON.stringify(formObj);

    return this.http.post<Exam>(
      this.URL + '/generate',
      serializedForm,
      {
        headers: new HttpHeaders({
          "Content-Type": 'application/json; charset=utf-8',
          "Accept": "*/*"
      })
      },        
    );
  }

  checkExam(checkExamForm: FormGroup) {
    let formObj = checkExamForm.value;
    let serializedForm = JSON.stringify(formObj);

    return this.http.post<Exam>(
      this.URL + '/check',
      serializedForm,
      {
        headers: new HttpHeaders({
          "Content-Type": 'application/json; charset=utf-8',
          "Accept": "*/*"
      })
      },        
    );
  }
}