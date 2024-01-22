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

    console.log(serializedForm);

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

  // TODO: remove
  check(checkQuestionForm: FormGroup) {
    let formObj = checkQuestionForm.value;
    let serializedForm = JSON.stringify(formObj);

    console.log(serializedForm)
    return this.http.post<boolean>(
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