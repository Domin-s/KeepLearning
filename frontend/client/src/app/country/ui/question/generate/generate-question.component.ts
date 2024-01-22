import { Component, inject } from "@angular/core";
import { Router, RouterLink } from "@angular/router";
import { FormGroup, FormsModule, ReactiveFormsModule } from "@angular/forms";
import { CategorySelectComponent } from "../../../shared/category/category-select/category-select.component";
import { GenerateQuestionForm } from "../../../forms/generateQuestion.form";
import { ContinentSelectComponent } from "../../../shared/continents/continent-select/continent-select.component";
import { QuestionService } from "../../../services/question.service";
import { SharingDataService } from "../../exam/SharingData.service";

@Component({
  standalone: true,
  selector: 'app-generate-question',
  templateUrl: './generate-question.component.html',
  styleUrl: './generate-question.component.scss',
  imports: [
    ContinentSelectComponent,
    CategorySelectComponent,
    FormsModule,
    ReactiveFormsModule,
    RouterLink,
  ],
  providers: [
    GenerateQuestionForm
  ],
})
export class GenerateQuestionComponent {
  private questionCountryStorageName = "QuestionCountry";
  private questionCountryParametersStorageName = "QuestionCountryParameters";
  public generateQuestionForm = inject(GenerateQuestionForm).form;

  constructor (
    private questionService: QuestionService,
    private router: Router,
    private sharingDataService: SharingDataService,
  ) {}

  onSubmit() {
    this.questionService.generate(this.generateQuestionForm).subscribe({
      next: (result) => {
        this.sharingDataService.setData(result, this.questionCountryStorageName);
        this.sharingDataService.setData(this.generateQuestionForm.value, this.questionCountryParametersStorageName);

        this.router.navigate(['/country/question/resolve']);
      },
      error: (err) => {
        console.log(err);
      }
    });
  }
}
