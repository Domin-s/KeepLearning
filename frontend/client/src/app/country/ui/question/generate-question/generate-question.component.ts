import { Component, OnInit, inject } from "@angular/core";
import { SharingDataService } from "../../exam/SharingData.service";
import { ActivatedRoute, Router, RouterLink } from "@angular/router";
import { FormArray, FormControl, FormsModule, ReactiveFormsModule } from "@angular/forms";
import { ContinentsCheckboxComponent } from "../../../shared/continents/continents-checkbox/continents-checkbox.component";
import { CategorySelectComponent } from "../../../shared/category/category-select/category-select.component";
import { GenerateQuestionForm } from "../../../forms/generateQuestion.form";

@Component({
  standalone: true,
  selector: 'app-generate-question',
  templateUrl: './generate-question.component.html',
  styleUrl: './generate-question.component.scss',
  imports: [
    ContinentsCheckboxComponent,
    CategorySelectComponent,
    FormsModule,
    ReactiveFormsModule,
    RouterLink,
  ],
  providers: [GenerateQuestionForm],
})
export class GenerateQuestionComponent implements OnInit {
  private storageName = "QuestionCountry";
  private generateQuestionForm = inject(GenerateQuestionForm).form;

  public continentsChecked: string[] = [];  
  public url = 'http://localhost:4200/country/resolveExam';

  constructor (
    private sharingDataService: SharingDataService,
    private route: ActivatedRoute,
    private router: Router,
  ) {}

  onSubmit() {
    this.setContinents();
    
    // this.examService.generateExam(this.generateExamForm).subscribe({
    //   next: (result) => {
    //     this.sharingDataService.setData(result, this.storageName);
    //     this.router.navigate(['/country/resolveExam']);
    //   },
    //   error: (err) => {

    //   }
    // });
  }

  setContinents() {
    this.contientsFromContinentsChecked.clear();
    this.continentsChecked.forEach(c => this.contientsFromContinentsChecked.push(new FormControl(c)));
  }

  get contientsFromContinentsChecked() {
    return this.generateQuestionForm.controls['Continents'] as FormArray
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
