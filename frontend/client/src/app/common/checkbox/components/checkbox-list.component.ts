import { Component, EventEmitter, Input, OnInit, Output, forwardRef } from '@angular/core';
import { Checkbox } from '../model/checkbox';
import { CheckboxComponent } from '../component/checkbox.component';
import { NG_VALUE_ACCESSOR, ReactiveFormsModule } from '@angular/forms';
import { ControlValueAccessorDirective } from '../../control-value-accessor.directive';

@Component({
  standalone: true,
  selector: 'app-checkbox-list',
  templateUrl: './checkbox-list.component.html',
  styleUrl: './checkbox-list.component.scss',
  imports: [
    CheckboxComponent,
    ReactiveFormsModule
  ],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => CheckboxListComponent),
      multi: true,
    },
  ],
})
export class CheckboxListComponent<T> extends ControlValueAccessorDirective<T> {
  @Input({ required: true}) checkboxes!: Checkbox[];
  @Input({ required: true }) inOneLine!: boolean;

  @Output() changeCheckForCheckboxesEvent = new EventEmitter();

  checkOrUncheckChild(checkbox: Checkbox) {
    this.changeCheckForCheckboxesEvent.emit(this.checkboxes);
  }
}
