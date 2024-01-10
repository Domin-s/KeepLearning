import { Component, Input, OnInit, ViewChild, inject } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { ContinentsCheckboxComponent } from '../../../shared/continents/continents-checkbox/continents-checkbox.component';
import { CategorySelectComponent } from '../../../shared/category/category-select/category-select.component';
import { NumberOfQuestionsSelectComponent } from '../../../shared/question/number-of-questions-select/number-of-questions-select.component';
import { ExamService } from '../../../services/exam.service';
import { FormsModule, NgForm } from '@angular/forms';
import { GenerateExamForm } from '../../../forms/generateExam.form';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  standalone: true,
  selector: 'app-generate-exam',
  templateUrl: './generate-exam.component.html',
  styleUrl: './generate-exam.component.scss',
  imports: [
    ContinentsCheckboxComponent,
    CategorySelectComponent,
    NumberOfQuestionsSelectComponent,
    RouterLink,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [GenerateExamForm],
})
export class GenerateExamComponent implements OnInit {
  readonly generateExamForm = inject(GenerateExamForm).form;

  public continentsChecked: string[] = [];
  
  public url = 'http://localhost:4200/country/resolveExam';

  defaultQuestion = "pet";

  constructor (
    private route: ActivatedRoute,
    private router: Router,
    private examService: ExamService
  ) {}

  onSubmit(event: Event) {
    console.log("GenerateExamComponent => onSubmit()")
    console.log(this.generateExamForm);

    // this.examService.generateExam(this.form.value).subscribe({
    //   next: (result) => {
    //     this.router.navigateByUrl('/country/resolveExam')
    //   },
    //   error: (err) => {

    //   }
    // });
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
      continentsFromPath = params.getAll('continentsChecked');
    });

    return continentsFromPath;
  }
}
