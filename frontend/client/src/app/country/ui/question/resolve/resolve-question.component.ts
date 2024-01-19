import { Component, OnInit, inject } from "@angular/core";
import { QuestionService } from "../../../services/exam.service copy";
import { SharingDataService } from "../../exam/SharingData.service";
import { Question } from "../../../models/Question";
import { FormControl, FormGroup } from "@angular/forms";
import { GenerateQuestionForm } from "../../../forms/generateQuestion.form";
import { Category } from "../../../models/Category";
import { RouterLink } from "@angular/router";

@Component({
  standalone: true,
  selector: 'app-resolve-question',
  templateUrl: './resolve-question.component.html',
  styleUrl: './resolve-question.component.scss',
  imports: [
    RouterLink
  ]
})
export class ResolveQuestionComponent implements OnInit {
  private questionCountryStorageName = "QuestionCountry";
  private questionCountryParametersStorageName = "QuestionCountryParameters";
  private generateQuestionForm = inject(GenerateQuestionForm).form;
  
  public parameters!: { Category: string, Continent: string };
  public question!: Question;
  public isBeforeChecked! :  boolean;

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
        this.isBeforeChecked = true;
      },
      error: (err) => {

      }
    });
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