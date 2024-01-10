import { Component, OnChanges, OnInit, SimpleChanges, inject } from '@angular/core';
import { Select } from '../../../../common/select/model/select';
import { ExamService } from '../../../services/exam.service';
import { SelectComponent } from '../../../../common/select/component/select.component';
import { GenerateExamForm } from '../../../forms/generateExam.form';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-category-select',
  standalone: true,
  imports: [
    SelectComponent
  ],
  templateUrl: './category-select.component.html',
  styleUrl: './category-select.component.scss'
})
export class CategorySelectComponent implements OnInit, OnChanges {
  public cetegoriesSelect: Select | undefined;

  private examService: ExamService = inject(ExamService);

  generateExamForm : FormGroup = inject(GenerateExamForm).form;

  // parentForm: FormGroup = inject(GenerateExamForm).form;;
  constructor(private formBuilder: FormBuilder) { }
  ngOnChanges(changes: SimpleChanges): void {
    console.log(this.generateExamForm);
  }
  
  ngOnInit(): void {
    this.getCategories();
    this.generateExamForm = this.formBuilder.group({
      Categories: ['Capital City', Validators.required]
    });

    console.log(this.generateExamForm)
  }

  getCategories() {
    this.examService.getCategories().subscribe({
      next: (result) => {
        this.cetegoriesSelect = new Select(
          "Select-Categories",
          "Categories",
          "Choose guess type",
          result
        );;
      },
      error: (error) => {
        console.log(error);
      }
    })
  }
}
