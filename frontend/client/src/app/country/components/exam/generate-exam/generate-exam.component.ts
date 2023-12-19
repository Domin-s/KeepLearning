import { Component, inject } from '@angular/core';
import { RouterLink } from '@angular/router';
import { SelectComponent } from '../../../../common/select/component/select.component';
import { Select } from '../../../../common/select/model/select';
import { ExamService } from '../../../services/exam.service';
import { ContinentService } from '../../../services/continent.service';
import { ContinentsCheckboxComponent } from '../../../shared/continents/continents-checkbox/continents-checkbox.component';

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
  public cetegoriesSelect!: Select;
  public numberOfQuestionSelect!: Select;

  private numberOfQuestionToChoose: number[] = [5, 10, 20, 25, 50, 100];
  
  
  private examService: ExamService = inject(ExamService);
  private continentService: ContinentService = inject(ContinentService);

  ngOnInit(): void {
    this.cetegoriesSelect = this.getCategoriesSelect();
    this.setNumberOfQuestionSelect();
  }

  getCategoriesSelect(): Select {
    let categories: string[] = this.getCategories();

    return new Select(
      "Select-Categories",
      "Categories",
      "Choose guess type",
      categories
    );
  }

  getCategories(): string[] {
    let categories: string[] = [];

    this.examService.getCategories().subscribe({
      next: (result) => {
        categories = result;
      },
      error: (error) => {
        console.log(error);
      }
    })

    return categories;
  }

  setNumberOfQuestionSelect(){
    let maxNumberOfQuestion: number = this.getMaxNumbersOfQuestion();
    let numersOfQuestion: number[] = this.getNumbersOfQuestion(maxNumberOfQuestion, this.numberOfQuestionToChoose);

    this.cetegoriesSelect = new Select(
      "Select-NumberOfQuestion",
      "NumberOfQuestion",
      "Choose number of question",
      numersOfQuestion
    );
  }

  getMaxNumbersOfQuestion(): number {
    let numberOfQuestion = 0;

    this.continentService.getNumberOfCountries().subscribe({
      next: (result) => {
        numberOfQuestion = result;
      },
      error: (error) => {
        console.log(error);
      }
    })

    return numberOfQuestion;
  }

  getNumbersOfQuestion(maxNumber: number, numbersToChoose: number[]): number[] {
    let numbers: number[] = [];

    for (let i = 0; i < numbersToChoose.length; i++) {
      const element = numbersToChoose[i];
      if(element < maxNumber) {
        numbers.push(element);
      } else {
        break;
      }
    }

    return numbers;
  }

  goToCreatorToGenerateRandomQuestion(){
    console.log("ListOfCountriesComponent => goToCreatorToGenerateRandomQuestion");
  }
}
