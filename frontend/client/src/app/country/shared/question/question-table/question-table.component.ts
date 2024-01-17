import { Component, Input, OnInit } from '@angular/core';
import { Question } from '../../../models/Question';
import { FormArray, FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-question-table',
  standalone: true,
  imports: [
    ReactiveFormsModule
  ],
  templateUrl: './question-table.component.html',
  styleUrl: './question-table.component.scss'
})
export class QuestionTableComponent {
  @Input({ required: true }) questions: Question[] = [];
  @Input({ required: true }) questionCategory: string = "";
  @Input({ required: true }) answerCategory: string = "";

  isChecked = false;

  checkExamForm: FormGroup;

  constructor(){
    this.checkExamForm = new FormGroup({
      'Category': new FormControl(''),
      'Answers': new FormArray([])
    });
  }

  onSubmit(){
    console.log(this.checkExamForm.value);
    this.isChecked = true;
  }
}
