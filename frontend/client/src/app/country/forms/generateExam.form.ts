import { Injectable } from "@angular/core"
import { FormBuilder, Validators } from "@angular/forms"

@Injectable({
    providedIn: "root",
})
export class GenerateExamForm {
    form;
   
    constructor(private formBuilder: FormBuilder) {
        this.form = this.formBuilder.group({
            Name: [''],
            NumberOfQuestion: [10, Validators.required],
            Category: ['Capital City', Validators.required],
            Continents: this.formBuilder.array([this.formBuilder.control('Europe')], Validators.required)
        })
    }
}
