import { Component, Input, OnInit, Output, inject, EventEmitter } from '@angular/core';
import { CheckboxListComponent } from '../../../../common/checkbox/components/checkbox-list.component';
import { Checkbox } from '../../../../common/checkbox/model/checkbox';
import { ContinentCheckbox } from '../../../services/ContinentCheckbox';

@Component({
  selector: 'app-continents-checkbox',
  standalone: true,
  imports: [CheckboxListComponent],
  templateUrl: './continents-checkbox.component.html',
  styleUrl: './continents-checkbox.component.scss'
})
export class ContinentsCheckboxComponent implements OnInit { 
  @Input({ required: true }) inOneLine!: boolean;
  @Input({ required: true }) isForm!: boolean;
  @Input() continentsChecked: string[] = ['Africa', 'Asia', 'Australia', 'Europe', 'North America', 'South America'];

  @Output() updateCheckoboxesEvent = new EventEmitter<string[]>();

  public continentCheckbox: ContinentCheckbox;

  constructor(
  ){
    this.continentCheckbox = new ContinentCheckbox();
  }

  ngOnInit(): void {
    this.continentCheckbox.setCheckedContinents(this.continentsChecked);
  }

  updateContinentChecboxes(checkboxes: Checkbox[]) {
    this.continentCheckbox.checkOrUncheckContinents(checkboxes);
    this.continentsChecked = this.continentCheckbox.getCheckedContinents().map(c => c.value);
    this.updateCheckoboxesEvent.emit(this.continentsChecked)
  }
}
