import { Component, Input, OnInit, Output, EventEmitter, inject } from '@angular/core';
import { Checkbox } from '../model/checkbox';
import { GenerateExamForm } from '../../../country/forms/generateExam.form';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  standalone: true,
  selector: 'app-checkbox',
  templateUrl: './checkbox.component.html',
  styleUrl: './checkbox.component.scss',
  imports: [ReactiveFormsModule]
})
export class CheckboxComponent implements OnInit {
  @Input({ required: true }) checkbox!: Checkbox;
  @Input({ required: true }) inOneLine!: boolean;

  @Output() changeCheckForCheckboxEvent = new EventEmitter();

  readonly generateExamForm = inject(GenerateExamForm).form;

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
