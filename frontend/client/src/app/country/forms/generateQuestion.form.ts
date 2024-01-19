import { Injectable } from "@angular/core"
import { FormBuilder, Validators } from "@angular/forms"

@Injectable({
    providedIn: "root",
})
export class GenerateQuestionForm {
    form;
   
    constructor(private formBuilder: FormBuilder) {
        this.form = this.formBuilder.group({
            Category: ['Capital City', Validators.required],
            Continent: ['Europe', Validators.required],
        })
    }
}
