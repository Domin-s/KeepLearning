import { Component, Input, inject } from '@angular/core';
import { QuestionService } from '../../../../services/question.service';
import { UserAnswer } from '../../../../models/UserAnswer';
import { Question } from '../../../../models/Question';
import { ResolveQuestionForm } from '../forms/resolve-question.form';
import { Answer } from '../../../../models/Answer';
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
  
  public resolveQuestionForm = inject(ResolveQuestionForm).form;

  public answerHistory: UserAnswer[] = [];
  private answer!: Answer;
  private userAnswer!: UserAnswer;

  constructor(
    private questionService: QuestionService
  ){}

  onSubmit() {
    this.questionService.check(this.resolveQuestionForm).subscribe({
      next: result => {
        this.answer = result;
        this.userAnswer = this.createUserAnswer(this.answer, this.question.questionText);
        this.addAnswerToAnswerHistory(this.userAnswer);
      },
      error: error => {
        console.log(error);
      }
    })
  }

  addAnswerToAnswerHistory(userAnswer: UserAnswer){
    console.log("addAnswerToAnswerHistory");   
    console.log(this.answerHistory);
    this.answerHistory.push(userAnswer);
    console.log(this.answerHistory);
  }

  createUserAnswer(answer: Answer, questionText: string): UserAnswer {
    let userAnswer = {
      QuestionText: questionText,
      UserAnswer: answer.userAnswer,
      IsCorrect: answer.correctAnswer === answer.userAnswer
    }

    return userAnswer; 
  }
}
