import { Component, OnInit } from '@angular/core';
import { Exam } from '../../../models/Exam';
import { QuestionTableComponent } from '../../../shared/question/question-table/question-table.component';
import { RouterLink } from '@angular/router';
import { SharingDataService } from '../SharingData.service';
import { FormArray, FormControl, FormGroup } from "@angular/forms";
import { Category } from '../../../models/Category';
import { ExamService } from '../../../services/exam.service';

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
  public continentsChecked: string[] = [];
  public isBeforeChecked! :  boolean;

  constructor(
    private sharingDataService: SharingDataService,
    private examService: ExamService
  ){}

  ngOnInit(): void {
    let exam = this.sharingDataService.getData(this.storageName);

    if (exam !== null){
      this.exam = exam;
      this.questionCategory = Category[(exam.category + 1) % 2];
      this.answerCategory = Category[exam.category];
    }

    this.isBeforeChecked = true;
    
    this.addContinentToQueryParam();
  }

  addContinentToQueryParam(){
    for (let continent  of this.exam.continents) {
      this.continentsChecked.push(continent.name);
    }
  }

  createNewExamWithSameParameters(){
    this.examService.generateExam(this.generateFormGroup()).subscribe({
      next: (result) => {
        this.sharingDataService.setData(result, this.storageName);
        this.exam = result;
        this.isBeforeChecked = true;
      },
      error: (err) => {

      }
    });
  }

  generateFormGroup(): FormGroup {
    let form = new FormGroup({
      Name: new FormControl(this.exam.name),
      NumberOfQuestion: new FormControl(this.exam.questions.length),
      Category: new FormControl(Category[this.exam.category]),
      Continents: this.createContinentArrayForm()
    });

    return form;
  }

  createContinentArrayForm(): FormArray {
    let arrayForm: FormArray<any> = new FormArray<any>([]);

    for (let continent of this.exam.continents) {
      arrayForm.push(new FormControl(continent.name));
    }

    return arrayForm;
  }

  changeCheckedExam(value: boolean) {
    this.isBeforeChecked = value;
  }
}
