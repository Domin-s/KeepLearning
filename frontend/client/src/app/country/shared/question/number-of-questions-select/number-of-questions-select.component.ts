import { Component, inject } from '@angular/core';
import { ContinentService } from '../../../services/continent.service';
import { Select } from '../../../../common/select/model/select';
import { SelectComponent } from '../../../../common/select/component/select.component';

@Component({
  selector: 'app-number-of-questions-select',
  standalone: true,
  imports: [
    SelectComponent
  ],
  templateUrl: './number-of-questions-select.component.html',
  styleUrl: './number-of-questions-select.component.scss'
})
export class NumberOfQuestionsSelectComponent {
  public numberOfQuestionSelect!: Select;

  private numberOfQuestionToChoose: number[] = [5, 10, 20, 25, 50, 100];
  private continentService: ContinentService = inject(ContinentService);


  setNumberOfQuestionSelect(){
    let maxNumberOfQuestion: number = this.getMaxNumbersOfQuestion();
    let numersOfQuestion: number[] = this.getNumbersOfQuestion(maxNumberOfQuestion, this.numberOfQuestionToChoose);

    this.numberOfQuestionSelect = new Select(
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
}
