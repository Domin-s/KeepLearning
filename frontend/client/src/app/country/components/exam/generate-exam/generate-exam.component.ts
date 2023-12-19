import { Component, inject } from '@angular/core';
import { RouterLink } from '@angular/router';
import { ContinentsCheckboxComponent } from '../../continents/continents-checkbox/continents-checkbox.component';
import { SelectComponent } from '../../../../common/select/component/select.component';
import { Select } from '../../../../common/select/model/select';
import { ExamService } from '../../../services/exam.service';

@Component({
  standalone: true,
  selector: 'app-generate-exam',
  templateUrl: './generate-exam.component.html',
  styleUrl: './generate-exam.component.scss',
  imports: [
    ContinentsCheckboxComponent,
    RouterLink,
    SelectComponent
  ]
})
export class GenerateExamComponent {
  public select!: Select;

  private examService: ExamService = inject(ExamService);

  ngOnInit(): void {
    this.getCategories();
  }

  goToCreatorToGenerateRandomQuestion(){
    console.log("ListOfCountriesComponent => goToCreatorToGenerateRandomQuestion");
  }

  getCategories() {
    this.examService.getCategories().subscribe({
      next: (result) => {
        this.select = new Select(
          "Category",
          "Category",
          "Choose a guess type:",
          result
        );
      },
      error: (error) => {
        console.log(error);
      }
    })
  }
}
