import { Component, Input, OnInit, Output, EventEmitter, inject, forwardRef } from '@angular/core';
import { Checkbox } from '../model/checkbox';

@Component({
  selector: 'app-checkbox',
  templateUrl: './checkbox.component.html',
  styleUrl: './checkbox.component.scss',
  standalone: true
})
export class CheckboxComponent implements OnInit {
  @Input({ required: true }) checkbox!: Checkbox;
  @Input({ required: true }) inOneLine!: boolean;

  @Output() changeCheckForCheckboxEvent = new EventEmitter();

  public classes = '';

  ngOnInit(): void {
    this.classes = this.setClassToComponent(this.inOneLine);
  }

  setClassToComponent(inOneLine: boolean) {
    if (inOneLine) {
      return "form-check form-check-inline";
    } else {
      return "form-check";
    }
  }

  changeCheck() {
    this.changeStatus();
    this.changeCheckForCheckboxEvent.emit(this.checkbox);
  }

  changeStatus() {
    this.checkbox.isChecked = !this.checkbox.isChecked;
  }
}
