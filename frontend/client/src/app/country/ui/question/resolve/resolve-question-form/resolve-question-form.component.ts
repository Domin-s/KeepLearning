import { Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild, inject } from '@angular/core';
import { QuestionService } from '../../../../services/question.service';
import { UserAnswer } from '../../../../models/UserAnswer';
import { Question } from '../../../../models/Question';
import { ResolveQuestionForm } from '../forms/resolve-question.form';
import { Answer } from '../../../../models/Answer';
import { FormControl, ReactiveFormsModule } from '@angular/forms';

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

  @Output() isAnsweredCorrect = new EventEmitter<boolean>();
  
  @ViewChild('userAnswerInput', {static: true}) userAnswerInput!: ElementRef;
  
  public answerHistory: UserAnswer[] = [];

  constructor(
  ) { }

  check() {
    console.log(this.answerHistory);
    let userAnswer = this.createUserAnswer(this.userAnswerInput.nativeElement.value, this.question);
    this.answerHistory.push(userAnswer);
    this.isAnsweredCorrect.emit(userAnswer.IsCorrect);
    this.userAnswerInput.nativeElement.value = '';
    console.log(this.answerHistory);
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
