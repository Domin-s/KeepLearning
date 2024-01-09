import { Component, Input, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { ContinentsCheckboxComponent } from '../../../shared/continents/continents-checkbox/continents-checkbox.component';
import { CategorySelectComponent } from '../../../shared/category/category-select/category-select.component';
import { NumberOfQuestionsSelectComponent } from '../../../shared/question/number-of-questions-select/number-of-questions-select.component';
import { Checkbox } from '../../../../common/checkbox/model/checkbox';
import { ExamService } from '../../../services/exam.service';
import { FormGroup } from '@angular/forms';

@Component({
  standalone: true,
  selector: 'app-generate-exam',
  templateUrl: './generate-exam.component.html',
  styleUrl: './generate-exam.component.scss',
  imports: [
    ContinentsCheckboxComponent,
    CategorySelectComponent,
    NumberOfQuestionsSelectComponent,
    RouterLink
  ]
})
export class GenerateExamComponent implements OnInit {
  @Input() continentsCheckbox: Checkbox[] = [];
  public continentsChecked: string[] = [];
  public url = 'http://localhost:4200/country/resolveExam';
  public form!: FormGroup;

  constructor (
    private route: ActivatedRoute,
    private router: Router,
    private examService: ExamService
  ) {}

  onSubmit() {
    console.log("GenerateExamComponent => onSubmit()")
    this.examService.generateExam(this.form.value).subscribe({
      next: (result) => {
        this.router.navigateByUrl('/country/resolveExam')
      },
      error: (err) => {

      }
    });
  }

  ngOnInit(): void {
    this.continentsChecked = this.getContinentsFromPath();
  }
  

  getCheckedContinents(continents: string[]){
    this.continentsChecked = continents;
  }

  getContinentsFromPath(){
    let continentsFromPath: string[] = []; 
    
    this.route.queryParamMap.subscribe( params => {
      continentsFromPath = params.getAll('continents');
    });

    return continentsFromPath;
  }
}
