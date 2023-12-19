import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { ContinentsCheckboxComponent } from '../../continents/continents-checkbox/continents-checkbox.component';

@Component({
  standalone: true,
  selector: 'app-generate-exam',
  templateUrl: './generate-exam.component.html',
  styleUrl: './generate-exam.component.scss',
  imports: [
    ContinentsCheckboxComponent,
    RouterLink
  ]
})
export class GenerateExamComponent {

}
