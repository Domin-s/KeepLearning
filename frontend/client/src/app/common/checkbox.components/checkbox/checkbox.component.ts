import { Component, Input, OnInit } from '@angular/core';
import { Checkbox } from '../model/checkbox';

@Component({
  standalone: true,
  selector: 'app-checkbox',
  templateUrl: './checkbox.component.html',
  styleUrl: './checkbox.component.css'
})
export class CheckboxComponent {
  @Input({ required: true }) checkbox!: Checkbox;
}
