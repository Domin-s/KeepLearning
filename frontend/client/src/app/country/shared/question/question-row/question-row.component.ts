import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { Question } from '../../../models/Question';
import { Answer } from '../../../models/Answer';
import { ControlContainer, FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'tr[app-question-row]',
  standalone: true,
  imports: [
    ReactiveFormsModule
  ],
  templateUrl: './question-row.component.html',
  styleUrl: './question-row.component.scss'
})
export class QuestionRowComponent implements OnInit, OnChanges {
  @Input({ required: true }) question!: Question;
  @Input({ required: true }) formGroupName!: string;
  @Input({ required: true }) isBeforeChecked!: boolean;

  @Input() corectAnswer?: Answer;

  inputClasses = ["form-control", "input-answer-border-radius"]
  formAnswer!: FormGroup;
  showCorrectAnswer: boolean = true;

  constructor(
    private controlContainer: ControlContainer
  ) {}

  ngOnChanges(changes: SimpleChanges): void {
    this.setClasses();

    if (!this.isCorrect()){
      this.setEmptyValue()
    }
    
    this.formAnswer = <FormGroup>this.controlContainer.control;
    this.showCorrectAnswer = true;
  }

  ngOnInit(): void {
    this.formAnswer = <FormGroup>this.controlContainer.control;
  }

  setClasses() {
    if(this.isCorrect()) {
      this.inputClasses = ["form-control", "input-answer-border-radius", "correct-answer"];
    } else {
      this.inputClasses = ["form-control", "input-answer-border-radius", "incorrect-answer"];
    }
  }

  setEmptyValue(){
    if(this.corectAnswer?.userAnswer === ''){
      this.corectAnswer.userAnswer = 'Empty!';
    }
  }

  isCorrect(): boolean {
    return  this.corectAnswer?.userAnswer === this.corectAnswer?.correctAnswer;
  }

  changeShowingAnswer(){
    this.showCorrectAnswer = !this.showCorrectAnswer
  }
}
