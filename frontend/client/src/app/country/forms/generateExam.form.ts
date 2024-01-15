import { Injectable, inject } from "@angular/core"
import { FormBuilder, Validators } from "@angular/forms"

@Injectable()
export class GenerateExamForm {
    form;
   
    constructor(private formBuilder: FormBuilder) {
        this.form = this.formBuilder.group({
            Name: [''],
            NumberOfQuestion: [10, Validators.required],
            Category: ['Country', Validators.required],
            Continents: this.formBuilder.array([this.formBuilder.control('Europe')], Validators.required)
        })
    }
}
