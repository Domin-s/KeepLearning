import { Component, OnInit, inject } from '@angular/core';
import { Select } from '../../../../common/select/model/select';
import { ExamService } from '../../../services/exam.service';
import { SelectComponent } from '../../../../common/select/component/select.component';

@Component({
  selector: 'app-category-select',
  standalone: true,
  imports: [
    SelectComponent
  ],
  templateUrl: './category-select.component.html',
  styleUrl: './category-select.component.scss'
})
export class CategorySelectComponent implements OnInit {
  public cetegoriesSelect!: Select;

  private examService: ExamService = inject(ExamService);
  
  ngOnInit(): void {
    this.getCategories();
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
