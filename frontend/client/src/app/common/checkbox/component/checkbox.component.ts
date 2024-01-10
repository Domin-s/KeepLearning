import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { Checkbox } from '../model/checkbox';

@Component({
  standalone: true,
  selector: 'app-checkbox',
  templateUrl: './checkbox.component.html',
  styleUrl: './checkbox.component.css'
})
export class CheckboxComponent implements OnInit {
  @Input({ required: true }) checkbox!: Checkbox;
  @Input({ required: true }) inOneLine!: boolean;

  @Output() changeCheckForCheckboxEvent = new EventEmitter();

  public classes = ""

  ngOnInit(): void {
    this.setClassToComponent();
  }

  setClassToComponent() {
    if (this.inOneLine) {
      this.classes = "form-check form-check-inline"
    } else {
      this.classes = "form-check"
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
