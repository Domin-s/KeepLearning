import { Component,  OnInit, inject } from '@angular/core';
import { ActivatedRoute,  Router,  RouterLink } from '@angular/router';
import { ContinentsCheckboxComponent } from '../../../shared/continents/continents-checkbox/continents-checkbox.component';
import { CategorySelectComponent } from '../../../shared/category/category-select/category-select.component';
import { NumberOfQuestionsSelectComponent } from '../../../shared/question/number-of-questions-select/number-of-questions-select.component';
import { ExamService } from '../../../services/exam.service';
import { FormArray, FormControl, FormsModule, NgForm } from '@angular/forms';
import { GenerateExamForm } from '../../../forms/generateExam.form';
import { ReactiveFormsModule } from '@angular/forms';
import { Exam } from '../../../models/Exam';
import { SharingDataService } from '../SharingData.service';

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
  private storageName = "ExamCountry";
  generateExamForm = inject(GenerateExamForm).form;
  public continentsChecked: string[] = [];
  
  public url = 'http://localhost:4200/country/resolveExam';

  constructor (
    private examService: ExamService,
    private sharingDataService: SharingDataService,
    private route: ActivatedRoute,
    private router: Router,
  ) {}

  onSubmit() {
    this.setContinents();
    
    this.examService.generateExam(this.generateExamForm).subscribe({
      next: (result) => {
        this.setDataToExamDataService(result);
        this.router.navigate(['/country/resolveExam']);
      },
      error: (err) => {

      }
    });
  }

  setDataToExamDataService(exam: Exam) {
    this.sharingDataService.setData(exam, this.storageName);
  }

  setContinents() {
    this.contientsFromContinentsChecked.clear();
    this.continentsChecked.forEach(c => this.contientsFromContinentsChecked.push(new FormControl(c)));
  }

  get contientsFromContinentsChecked() {
    return this.generateExamForm.controls['Continents'] as FormArray
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
