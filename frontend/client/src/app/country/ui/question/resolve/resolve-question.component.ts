import { Component, OnInit, inject } from "@angular/core";
import { QuestionService } from "../../../services/question.service";
import { SharingDataService } from "../../exam/SharingData.service";
import { Question } from "../../../models/Question";
import { FormControl, FormGroup } from "@angular/forms";
import { GenerateQuestionForm } from "../../../forms/generateQuestion.form";
import { RouterLink } from "@angular/router";
import { ResolveQuestionFormComponent } from "./resolve-question-form/resolve-question-form.component";
import { UserAnswer } from "../../../models/UserAnswer";
import { AnswerHistoryComponent } from "./answer-history/answer-history.component";

@Component({
  standalone: true,
  selector: 'app-resolve-question',
  templateUrl: './resolve-question.component.html',
  styleUrl: './resolve-question.component.scss',
  imports: [
    RouterLink,
    ResolveQuestionFormComponent,
    AnswerHistoryComponent
  ]
})
export class ResolveQuestionComponent implements OnInit {
  private generateQuestionForm = inject(GenerateQuestionForm).form;
  private questionCountryStorageName = "QuestionCountry";
  private questionCountryParametersStorageName = "QuestionCountryParameters";
  
  public parameters!: { Category: string, Continent: string };
  public question!: Question;
  
  public answerHistory: UserAnswer[] = [];

  constructor (
    private questionService: QuestionService,
    private sharingDataService: SharingDataService,
  ) {}

  ngOnInit(): void {
    this.question = this.sharingDataService.getData(this.questionCountryStorageName);
    this.generateQuestionForm = this.generateFormGroup();
  }


  createNewQuestionWithSameParameters(){
    this.getNewQuestion();
    this.answerHistory.push(this.createEmptyAnswer(this.question));
  }

  generateNextQuestion(userAnswer: UserAnswer){
    if (userAnswer.UserAnswer === '') {
      this.answerHistory.push(this.createEmptyAnswer(this.question));
    } else if (userAnswer.IsCorrect) {
      this.answerHistory.push(userAnswer);
      this.getNewQuestion();
    
    } else {
      this.answerHistory.push(userAnswer);
    }
  }

  getNewQuestion(){
    this.questionService.generate(this.generateFormGroup()).subscribe({
      next: (result) => {
        this.sharingDataService.setData(result, this.questionCountryStorageName);
        this.question = result;
      },
      error: (err) => {

      }
    });
  }
  createEmptyAnswer(question: Question){
    let emptyAnswer = {
      QuestionText: question.questionText,
      UserAnswer: '',
      CorrectAnswer: question.answerText,
      IsCorrect: false
    }

    return emptyAnswer;
  }

  generateFormGroup(): FormGroup {
    this.parameters = this.sharingDataService.getData(this.questionCountryParametersStorageName);

    let form = new FormGroup({
      Category: new FormControl(this.parameters.Category),
      Continent: new FormControl(this.parameters.Continent),
    });

    return form;
  }

}