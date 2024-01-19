import { Component, OnInit, inject } from "@angular/core";
import { Router, RouterLink } from "@angular/router";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { CategorySelectComponent } from "../../../shared/category/category-select/category-select.component";
import { GenerateQuestionForm } from "../../../forms/generateQuestion.form";
import { ContinentSelectComponent } from "../../../shared/continents/continent-select/continent-select.component";

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
  providers: [GenerateQuestionForm],
})
export class GenerateQuestionComponent implements OnInit {
  private generateQuestionForm = inject(GenerateQuestionForm).form;

  public url = 'http://localhost:4200/country/resolveExam';

  constructor (
    private router: Router,
  ) {}

  ngOnInit(): void {
    console.log(GenerateQuestionComponent);
  }

  onSubmit() {
    console.log(this.generateQuestionForm.value);
    // this.examService.generateExam(this.generateExamForm).subscribe({
    //   next: (result) => {
    //     this.router.navigate(['/country/resolveExam']);
    //   },
    //   error: (err) => {

    //   }
    // });
  }
}
