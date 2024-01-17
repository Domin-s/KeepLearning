import { Component, Input, OnInit } from '@angular/core';
import { Question } from '../../../models/Question';
import { AbstractControl, FormArray, FormControl, FormGroup, NgModel, ReactiveFormsModule } from '@angular/forms';
@Component({
  selector: 'app-question-table',
  standalone: true,
  imports: [
    ReactiveFormsModule
  ],
  templateUrl: './question-table.component.html',
  styleUrl: './question-table.component.scss'
})
export class QuestionTableComponent implements OnInit {
  @Input({ required: true }) questions!: Question[];
  @Input({ required: true }) questionCategory!: string;
  @Input({ required: true }) answerCategory!: string;

  isChecked = false;

  checkExamForm!: FormGroup;

  ngOnInit(): void {
    this.checkExamForm = new FormGroup({
      'Category': new FormControl(this.questionCategory),
      'Answers': this.getDefaultParametersForAnswers()
    });
  }

  getDefaultParametersForAnswers(): FormArray {
    let form = new FormArray<any>([]);

    for (let question of this.questions) {
      const control = new FormGroup({
        'NumberOfQuestion': new FormControl(question.questionNumber),
        'QuestionText': new FormControl(question.questionText),
        'AnswerText': new FormControl(''),
      })

      form.push(control);
    }

    return form;
  }

  get answerControls(): AbstractControl<any>[] {
    return (this.checkExamForm.get('Answers') as FormArray).controls;
  }

  onSubmit(){
    console.log(this.checkExamForm.value);
    // this.isChecked = true;
  }
}
