import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable, inject } from "@angular/core";
import { FormGroup } from "@angular/forms";
import { Question } from "../models/Question";
import { Answer } from "../models/Answer";

@Injectable({
  providedIn: "root",
})
export class QuestionService {
  private URL = "https://localhost:5001/api/country/question";

  constructor(private http: HttpClient) {}

  generate(generateQuestionForm: FormGroup) {
    let formObj = generateQuestionForm.value;
    let serializedForm = JSON.stringify(formObj);

    return this.http.post<Question>(
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

  check(checkExamForm: FormGroup) {
    let formObj = checkExamForm.value;
    let serializedForm = JSON.stringify(formObj);

    return this.http.post<Answer>(
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