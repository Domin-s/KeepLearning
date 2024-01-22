import { Component, OnInit, inject } from "@angular/core";
import { QuestionService } from "../../../services/question.service";
import { SharingDataService } from "../../exam/SharingData.service";
import { Question } from "../../../models/Question";
import { FormControl, FormGroup } from "@angular/forms";
import { GenerateQuestionForm } from "../../../forms/generateQuestion.form";
import { RouterLink } from "@angular/router";
import { ResolveQuestionFormComponent } from "./resolve-question-form/resolve-question-form.component";

@Component({
  standalone: true,
  selector: 'app-resolve-question',
  templateUrl: './resolve-question.component.html',
  styleUrl: './resolve-question.component.scss',
  imports: [
    RouterLink,
    ResolveQuestionFormComponent
  ]
})
export class ResolveQuestionComponent implements OnInit {
  private generateQuestionForm = inject(GenerateQuestionForm).form;
  private questionCountryStorageName = "QuestionCountry";
  private questionCountryParametersStorageName = "QuestionCountryParameters";
  
  public parameters!: { Category: string, Continent: string };
  public question!: Question;

  constructor (
    private questionService: QuestionService,
    private sharingDataService: SharingDataService,
  ) {}

  ngOnInit(): void {
    this.question = this.sharingDataService.getData(this.questionCountryStorageName);
    this.generateQuestionForm = this.generateFormGroup();
  }


  createNewQuestionWithSameParameters(){
    this.questionService.generate(this.generateFormGroup()).subscribe({
      next: (result) => {
        this.sharingDataService.setData(result, this.questionCountryStorageName);
        this.question = result;
      },
      error: (err) => {

      }
    });
  }

  generateNextQuestion(isCorrectAnswer: boolean){
    console.log("ResolveQuestionComponent => generateNextQuestion : " + isCorrectAnswer);
    if (isCorrectAnswer) {
      this.createNewQuestionWithSameParameters();
    }
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