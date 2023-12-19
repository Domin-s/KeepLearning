import { Component, Input, OnInit } from '@angular/core';
import { Checkbox } from '../model/checkbox';
import { CheckboxComponent } from '../component/checkbox.component';

@Component({
  standalone: true,
  selector: 'app-checkbox-list',
  templateUrl: './checkbox-list.component.html',
  styleUrl: './checkbox-list.component.css',
  imports: [CheckboxComponent]
})
export class CheckboxListComponent {
  @Input({ required: true}) checkboxes!: Checkbox[];
}
