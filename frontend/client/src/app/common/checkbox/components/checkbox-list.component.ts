import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Checkbox } from '../model/checkbox';
import { CheckboxComponent } from '../component/checkbox.component';

@Component({
  standalone: true,
  selector: 'app-checkbox-list',
  templateUrl: './checkbox-list.component.html',
  styleUrl: './checkbox-list.component.scss',
  imports: [CheckboxComponent]
})
export class CheckboxListComponent {
  @Input({ required: true}) checkboxes!: Checkbox[];
  @Input({ required: true }) inOneLine!: boolean;

  @Output() changeCheckForCheckboxesEvent = new EventEmitter();

  checkOrUncheckChild(checkbox: Checkbox) {
    this.changeCheckForCheckboxesEvent.emit(this.checkboxes)
  }
}
