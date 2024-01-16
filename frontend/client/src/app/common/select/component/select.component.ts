import { Component, ElementRef, Input, SimpleChanges, ViewChild, forwardRef } from '@angular/core';
import { Select } from '../model/select';
import { NG_VALUE_ACCESSOR, ReactiveFormsModule } from '@angular/forms';
import { ControlValueAccessorDirective } from '../../control-value-accessor.directive';

@Component({
  selector: 'app-select',
  templateUrl: './select.component.html',
  styleUrl: './select.component.scss',
  standalone: true,
  imports: [
    ReactiveFormsModule
  ],
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
  @ViewChild('selectItem') selectItem!: ElementRef;

  public actualOption = '';

  override ngOnInit(): void {
    super.ngOnInit();
  }

  ngOnChanges(changes: SimpleChanges): void {
    if(!changes['select'].isFirstChange()) {
      this.setDefaultOption();
    }
  }

  ngChangeValue(): void {
    this.actualOption = this.selectItem.nativeElement.value;
  }

  setDefaultOption(): string {
    if (!this.ifValueInOptions()) {
      let lastIndex = this.select.options.length - 1;
      this.actualOption = this.select.options[lastIndex];
    }

    return this.select.options[0];
  }

  ifValueInOptions(){
    return this.select.options
      .map(c => c.toString())
      .includes(this.selectItem.nativeElement.value);
  }
}
