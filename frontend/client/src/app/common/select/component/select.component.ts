import { Component, Input, forwardRef } from '@angular/core';
import { Select } from '../model/select';
import { FormControl, NG_VALUE_ACCESSOR, ReactiveFormsModule } from '@angular/forms';
import { ControlValueAccessorDirective } from '../../control-value-accessor.directive';

@Component({
  selector: 'app-select',
  standalone: true,
  imports: [
    ReactiveFormsModule
  ],
  templateUrl: './select.component.html',
  styleUrl: './select.component.scss',
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => SelectComponent),
      multi: true,
    },
  ],
})
export class SelectComponent<T> extends ControlValueAccessorDirective<T> {
  @Input({ required: true}) select!: Select;
}
