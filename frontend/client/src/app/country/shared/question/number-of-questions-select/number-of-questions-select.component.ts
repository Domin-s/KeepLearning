import { Component, Input, OnChanges, OnInit, SimpleChanges, inject } from '@angular/core';
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
export class NumberOfQuestionsSelectComponent implements OnInit, OnChanges {
  public numberOfQuestionSelect!: Select;
  
  @Input({ required: true }) continents: string[] = [];

  private numberOfQuestionToChoose: number[] = [5, 10, 20, 25, 50, 100];
  private continentService: ContinentService = inject(ContinentService);

  ngOnInit(): void {
    this.getMaxNumbersOfQuestion(this.continents);
  }

  ngOnChanges(changes: SimpleChanges): void {
    console.log("NumberOfQuestionsSelectComponent => ngOnChanges");
    console.log(changes);
    this.getMaxNumbersOfQuestion(this.continents);
  }

  getMaxNumbersOfQuestion(continents: string[]) {
    this.continentService.getNumberOfCountries(continents).subscribe({
      next: (result) => {
        console.log("getMaxNumbersOfQuestion ==>>" + result);
        this.numberOfQuestionSelect = new Select(
          "Select-NumberOfQuestion",
          "NumberOfQuestion",
          "Choose number of questions",
          this.getNumbersOfQuestion(result, this.numberOfQuestionToChoose)
        );
      },
      error: (error) => {
        console.log(error);
      }
    })
  }

  getNumbersOfQuestion(maxNumber: number, numbersToChoose: number[]): number[] {
    let numbers: number[] = [];

    for (let i = 0; i < numbersToChoose.length; i++) {
      const element = numbersToChoose[i];
      console.log(element);
      console.log(maxNumber);
      if(element < maxNumber) {
        numbers.push(element);
      } else {
        break;
      }
    }

    return numbers;
  }
}
