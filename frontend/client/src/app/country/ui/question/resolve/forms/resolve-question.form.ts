import { Injectable } from "@angular/core";
import { FormBuilder, Validators } from "@angular/forms";

@Injectable({
  providedIn: "root",
})
export class ResolveQuestionForm {
  form;
   
  constructor(private formBuilder: FormBuilder) {
      this.form = this.formBuilder.group({
          Question: ['', Validators.required],
          Answer: [''],
          Category: ['', Validators.required]
      })
  }
}