import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { Question } from '../../../models/Question';
import { AbstractControl, FormArray, FormControl, FormGroup, NgModel, ReactiveFormsModule } from '@angular/forms';
import { ExamService } from '../../../services/exam.service';
import { Result } from '../../../models/Result';
import { QuestionRowComponent } from '../question-table copy/question-row.component';
import { Answer } from '../../../models/Answer';
@Component({
  selector: 'app-question-table',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    QuestionRowComponent
  ],
  templateUrl: './question-table.component.html',
  styleUrl: './question-table.component.scss'
})
export class QuestionTableComponent implements OnInit {
  @Input({ required: true }) questions!: Question[];
  @Input({ required: true }) questionCategory!: string;
  @Input({ required: true }) answerCategory!: string;

  @ViewChild('answerInput', {static: true}) answerInput: ElementRef | undefined;

  public isChecked = false;
  public isBeforeChecked = true;
  public checkExamForm!: FormGroup;
  
  public result?: Result = {
    answerResults: [],
    numberOfGoodAnswers: 0,
    numberOfBadAnswers: 0
  };

  constructor(
    private examService: ExamService
  ){}

  ngOnInit(): void {
    this.checkExamForm = new FormGroup({
      'Category': new FormControl(this.questionCategory),
      'Answers': this.getDefaultParametersForAnswers()
    });
  }

  getDefaultParametersForAnswers(): FormArray {
    let form = new FormArray<any>([]);

    for (let question of this.questions) {
      const control = new FormGroup({
        'NumberOfQuestion': new FormControl(question.questionNumber),
        'QuestionText': new FormControl(question.questionText),
        'AnswerText': new FormControl(''),
      })

      form.push(control);
    }

    return form;
  }

  get answerControls(): AbstractControl<any>[] {
    return (this.checkExamForm.get('Answers') as FormArray).controls;
  }

  onSubmit(){
    console.log(this.checkExamForm.value);
    this.examService.checkExam(this.checkExamForm).subscribe({
      next: (result) => {
        this.result = result;
        this.isChecked = true;
        this.isBeforeChecked = false;
      },
      error: (error) => {
        console.log(error);
      }
    })
  }

  getCorrectAnswer(questionNumber: number) {
    return this.result?.answerResults.find(a => a.numberOfQuestion === questionNumber);
  }

}
