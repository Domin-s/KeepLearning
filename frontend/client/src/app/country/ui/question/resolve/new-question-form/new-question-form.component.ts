import { Component, EventEmitter, Input, Output } from '@angular/core';
import { QuestionParameters } from '../models/questionParameters';
import { Question } from '../../../../models/Question';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-new-question-form',
  standalone: true,
  imports: [
    RouterLink,
  ],
  templateUrl: './new-question-form.component.html',
  styleUrl: './new-question-form.component.scss'
})
export class NewQuestionFormComponent {
  @Input({ required: true }) parameters!: QuestionParameters;
  @Input({ required: true }) question!: Question;

  @Output() getNewQuestion = new EventEmitter<QuestionParameters>();

  createNewQuestion() {
    this.getNewQuestion.emit(this.parameters);
  }
}
