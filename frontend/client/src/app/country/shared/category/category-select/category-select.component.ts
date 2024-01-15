import { Component, Input, OnInit, inject } from '@angular/core';
import { Select } from '../../../../common/select/model/select';
import { ExamService } from '../../../services/exam.service';
import { SelectComponent } from '../../../../common/select/component/select.component';
import { GenerateExamForm } from '../../../forms/generateExam.form';
import { ReactiveFormsModule } from '@angular/forms';

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
        this.cetegoriesSelect = {
          id: "Select-Categories",
          name: "Categories",
          description: "Choose guess type",
          options: result
        };
      },
      error: (error) => {
        console.log(error);
      }
    })
  }
}
