import { Component, Input, OnInit, Output, inject, EventEmitter } from '@angular/core';
import { Checkbox } from '../../../../common/checkbox/model/checkbox';
import { ContinentCheckbox } from '../ContinentCheckbox';
import { GenerateExamForm } from '../../../forms/generateExam.form';
import { ReactiveFormsModule } from '@angular/forms';
import { CheckboxComponent } from '../../../../common/checkbox/component/checkbox.component';

@Component({
  selector: 'app-continents-checkbox',
  templateUrl: './continents-checkbox.component.html',
  styleUrl: './continents-checkbox.component.scss',
  standalone: true,
  imports: [
    CheckboxComponent,
    ReactiveFormsModule
  ],
})
export class ContinentsCheckboxComponent implements OnInit { 
  @Input({ required: true }) inOneLine!: boolean;
  @Input({ required: true }) isForm!: boolean;
  @Input() continentsChecked: string[] = ['Africa', 'Asia', 'Australia', 'Europe', 'North America', 'South America'];

  @Output() updateCheckoboxesEvent = new EventEmitter<string[]>();
  
  readonly generateExamForm = inject(GenerateExamForm).form;

  public continentCheckbox: ContinentCheckbox;

  constructor(){
    this.continentCheckbox = new ContinentCheckbox();
  }

  ngOnInit(): void {
    this.continentCheckbox.setCheckedContinents(this.continentsChecked);
  }

  updateContinentChecbox(checkbox: Checkbox) {
    this.continentCheckbox.checkOrUncheckContinent(checkbox);
    this.continentsChecked = this.continentCheckbox.getCheckedContinents().map(c => c.value);
    this.updateCheckoboxesEvent.emit(this.continentsChecked)
  }
}
