import { Component, OnInit } from '@angular/core';
import { Exam } from '../../../models/Exam';
import { QuestionTableComponent } from '../../../shared/question/question-table/question-table.component';
import { RouterLink } from '@angular/router';
import { SharingDataService } from '../SharingData.service';
import { Category } from '../../../models/Category';

@Component({
  selector: 'app-resolve-exam',
  templateUrl: './resolve-exam.component.html',
  styleUrl: './resolve-exam.component.scss',
  standalone: true,
  imports: [
    QuestionTableComponent,
    RouterLink
  ],
})
export class ResolveExamComponent implements OnInit {
  private storageName = "ExamCountry";

  public exam!: Exam;
  public questionCategory!: string;
  public answerCategory!: string;

  constructor(
    private sharingDataService: SharingDataService,
  ){}

  ngOnInit(): void {
    let exam = this.sharingDataService.getData(this.storageName);

    if (exam !== null){
      this.exam = exam;
      this.questionCategory = Category[(exam.category + 1) % 2];
      this.answerCategory = Category[exam.category];
    }
    
    console.log(this.exam);
  }
}
