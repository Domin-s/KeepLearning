import { Component, Input, OnChanges, OnInit, SimpleChanges, inject } from '@angular/core';
import { ContinentService } from '../../../services/continent.service';
import { Option, Select } from '../../../../common/select/model/select';
import { SelectComponent } from '../../../../common/select/component/select.component';
import { GenerateExamForm } from '../../../forms/generateExam.form';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-number-of-questions-select',
  standalone: true,
  imports: [
    SelectComponent,
    ReactiveFormsModule
  ],
  templateUrl: './number-of-questions-select.component.html',
  styleUrl: './number-of-questions-select.component.scss'
})
export class NumberOfQuestionsSelectComponent implements OnInit, OnChanges {
  @Input({ required: true }) continents: string[] = [];

  readonly generateExamForm = inject(GenerateExamForm).form;
  
  private numberOfQuestionToChoose: number[] = [5, 10, 20, 25, 50, 100];
  private continentService: ContinentService = inject(ContinentService);
  
  public numberOfQuestionSelect: Select | undefined;

  ngOnInit(): void {
    this.getMaxNumbersOfQuestion(this.continents);
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.getMaxNumbersOfQuestion(this.continents);
  }

  getMaxNumbersOfQuestion(continents: string[]) {
    this.continentService.getNumberOfCountries(continents).subscribe({
      next: (result) => {
        this.numberOfQuestionSelect = {
          id: "Select-NumberOfQuestion",
          name: "NumberOfQuestion",
          description: "Choose number of questions",
          options: this.getNumbersOfQuestion(result, this.numberOfQuestionToChoose)
        };
      },
      error: (error) => {
        console.log(error);
      }
    })
  }

  getNumbersOfQuestion(maxNumber: number, numbersToChoose: number[]): Option[] {
    let numbers: Option[] = [];

    for (let i = 0; i < numbersToChoose.length; i++) {
      const element = numbersToChoose[i];
      if(element < maxNumber) {
        numbers.push({name: element.toString(), value: element});
      } else {
        break;
      }
    }

    return numbers;
  }
}
