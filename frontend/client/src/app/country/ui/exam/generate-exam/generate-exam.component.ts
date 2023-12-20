import { Component, OnInit } from '@angular/core';
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
export class GenerateExamComponent implements OnInit {
  public continents: string[] = [];

  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }

  checkOrUncheckChild(itemValue: string) {
    console.log("GenerateExamComponent => checkOrUncheckChild => removeOrAddContinent => " + itemValue);
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
