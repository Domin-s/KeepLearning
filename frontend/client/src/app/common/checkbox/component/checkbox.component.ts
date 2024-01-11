import { Component, Input, OnInit, Output, EventEmitter, inject, forwardRef } from '@angular/core';
import { Checkbox } from '../model/checkbox';
import { GenerateExamForm } from '../../../country/forms/generateExam.form';
import { NG_VALUE_ACCESSOR, ReactiveFormsModule } from '@angular/forms';
import { ControlValueAccessorDirective } from '../../control-value-accessor.directive';

@Component({
  selector: 'app-checkbox',
  templateUrl: './checkbox.component.html',
  styleUrl: './checkbox.component.scss',
  standalone: true,
  imports: [
    ReactiveFormsModule
  ],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => CheckboxComponent),
      multi: true,
    },
  ],
})
export class CheckboxComponent<T> extends ControlValueAccessorDirective<T> {
  @Input({ required: true }) checkbox!: Checkbox;
  @Input({ required: true }) inOneLine!: boolean;

  @Output() changeCheckForCheckboxEvent = new EventEmitter();

  public classes = '';

  override ngOnInit(): void {
    super.ngOnInit();
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
