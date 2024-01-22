import { Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild, inject } from '@angular/core';
import { UserAnswer } from '../../../../models/UserAnswer';
import { Question } from '../../../../models/Question';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-resolve-question-form',
  standalone: true,
  imports: [
    ReactiveFormsModule,
  ],
  templateUrl: './resolve-question-form.component.html',
  styleUrl: './resolve-question-form.component.scss'
})
export class ResolveQuestionFormComponent {
  @Input({required: true}) public question!: Question;

  @Output() isAnsweredCorrect = new EventEmitter<UserAnswer>();
  
  @ViewChild('userAnswerInput', {static: true}) userAnswerInput!: ElementRef;

  constructor(
  ) { }

  check() {
    let userAnswer = this.createUserAnswer(this.userAnswerInput.nativeElement.value, this.question);
    this.isAnsweredCorrect.emit(userAnswer);
    this.userAnswerInput.nativeElement.value = '';
  }

  createUserAnswer(userAnswerText: string, question: Question): UserAnswer {
    let userAnswer = {
      QuestionText: question.questionText,
      UserAnswer: userAnswerText,
      CorrectAnswer: question.answerText,
      IsCorrect: question.answerText.toLocaleLowerCase() === userAnswerText.toLocaleLowerCase()
    }

    return userAnswer; 
  }
}
