import { Component, OnInit } from '@angular/core';
import { Exam } from '../../../models/Exam';
import { QuestionTableComponent } from '../../../shared/question/question-table/question-table.component';
import { ExamDataService } from '../examData.service';
import { RouterLink } from '@angular/router';

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
  public exam!: Exam;
  public questionCategory!: string;
  public answerCategory!: string;

  constructor(
    private examDataService: ExamDataService
  ){}

  ngOnInit(): void {
    this.examDataService.currentData.subscribe( data => {
      if (data !== undefined){
        this.exam = data;
      }
    });

    console.log(this.exam);
  }
}
