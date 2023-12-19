import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { ContinentsCheckboxComponent } from '../../../shared/continents/continents-checkbox/continents-checkbox.component';
import { ContinentSelectComponent } from '../../../shared/continents/continent-select/continent-select.component';
import { CategorySelectComponent } from '../../../shared/category/category-select/category-select.component';
import { NumberOfQuestionsSelectComponent } from '../../../shared/question/number-of-questions-select/number-of-questions-select.component';

@Component({
  standalone: true,
  selector: 'app-generate-exam',
  templateUrl: './generate-exam.component.html',
  styleUrl: './generate-exam.component.scss',
  imports: [
    ContinentsCheckboxComponent,
    CategorySelectComponent,
    NumberOfQuestionsSelectComponent,
    RouterLink
  ]
})
export class GenerateExamComponent {
  goToCreatorToGenerateRandomQuestion(){
    console.log("ListOfCountriesComponent => goToCreatorToGenerateRandomQuestion");
  }
}
