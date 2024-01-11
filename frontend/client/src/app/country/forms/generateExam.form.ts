import { Injectable, inject } from "@angular/core"
import { FormBuilder } from "@angular/forms"

@Injectable()
export class GenerateExamForm {
    readonly form = inject(FormBuilder).group({
        Name: [''],
        NumberOfQuestion: [10],
        Category: ['Country'],
        Continents: ['Europe']
    });

    constructor(){}
}
