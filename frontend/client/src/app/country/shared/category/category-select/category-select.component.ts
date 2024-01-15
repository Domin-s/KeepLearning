import { Component, Input, OnInit, inject } from '@angular/core';
import { Option, Select } from '../../../../common/select/model/select';
import { ExamService } from '../../../services/exam.service';
import { SelectComponent } from '../../../../common/select/component/select.component';
import { GenerateExamForm } from '../../../forms/generateExam.form';
import { ReactiveFormsModule } from '@angular/forms';
import { Category } from '../../../models/Category';

@Component({
  selector: 'app-category-select',
  standalone: true,
  imports: [
    SelectComponent,
    ReactiveFormsModule
  ],
  templateUrl: './category-select.component.html',
  styleUrl: './category-select.component.scss'
})
export class CategorySelectComponent implements OnInit {  
  readonly generateExamForm = inject(GenerateExamForm).form;

  public cetegoriesSelect: Select | undefined;
  
  constructor(
    private examService: ExamService
  ) { }
  
  ngOnInit(): void {
    this.getCategories();
  }

  getCategories() {
    this.examService.getCategories().subscribe({
      next: (result) => {
        let options: Option[] = this.createOptions(result);

        console.log(result);

        this.cetegoriesSelect = {
          id: "Select-Categories",
          name: "Categories",
          description: "Choose guess type",
          options: options
        };
      },
      error: (error) => {
        console.log(error);
      }
    })
  }

  createOptions(categories: Category[]): Option[] {
    let options = [];

    console.log(categories);

    for (let category of categories) {
      console.log(Category[category]);
      let newOption = {name: Category[category], value: category};

      options.push(newOption);
    }

    return options;
  }
}
