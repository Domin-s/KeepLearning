import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { ContinentsCheckboxComponent } from '../../../shared/continents/continents-checkbox/continents-checkbox.component';
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
  public continents: string[] = [];

  goToCreatorToGenerateRandomQuestion(){
    console.log("ListOfCountriesComponent => goToCreatorToGenerateRandomQuestion");
  }

  checkOrUncheckChild(itemValue: string) {
    console.log("ListOfCountriesComponent => checkOrUncheckChild => removeOrAddContinent => " + itemValue);
    this.removeOrAddContinent(itemValue);
  }

  removeOrAddContinent(continent: string) {
    let element = this.continents.find(c => c === continent);

    if (element === undefined) {
      this.continents.push(continent)
    } else {
      this.continents = this.continents.filter(c => c !== continent);
    }
  }
}
