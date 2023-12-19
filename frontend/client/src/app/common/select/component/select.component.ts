import { Component, Input } from '@angular/core';
import { Select } from '../model/select';

@Component({
  selector: 'app-select',
  standalone: true,
  imports: [],
  templateUrl: './select.component.html',
  styleUrl: './select.component.scss'
})
export class SelectComponent {
  @Input({ required: true}) select!: Select;
}
