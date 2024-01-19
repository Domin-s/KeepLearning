import { Component, OnInit, inject } from '@angular/core';
import { ContinentService } from '../../../services/continent.service';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { SelectComponent } from '../../../../common/select/component/select.component';
import { Select } from '../../../../common/select/model/select';
import { GenerateQuestionForm } from '../../../forms/generateQuestion.form';

@Component({
  selector: 'app-continent-select',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    SelectComponent
  ],
  templateUrl: './continent-select.component.html',
  styleUrl: './continent-select.component.scss'
})
export class ContinentSelectComponent implements OnInit {

  readonly generateQuestionForm = inject(GenerateQuestionForm).form;
  
  public continentsSelect: Select | undefined;
  
  constructor(
    private continentService: ContinentService
  ) {}

  ngOnInit(): void {
    this.getContinents();
  }

  getContinents() {
    this.continentService.getContinents().subscribe({
      next: (result) => {
        this.continentsSelect = {
          id: "Select-Categories",
          name: "Categories",
          description: "Choose guess type",
          options: result.map(c => c.name)
        }
      },
      error: (error) => {
        console.log(error);
      }
    })
  }
}
