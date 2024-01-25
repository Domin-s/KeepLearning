import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable, inject } from "@angular/core";
import { FormGroup } from "@angular/forms";
import { Question } from "../models/Question";
import { Answer } from "../models/Answer";

@Injectable({
  providedIn: "root",
})
export class QuestionService {
  private URL = process.env['SERVER_BACKEND_URL'] + '/country/question';

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
}
