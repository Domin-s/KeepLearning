import { Component, Input, OnInit } from '@angular/core';
import { Question } from '../../../models/Question';
import { Answer } from '../../../models/Answer';
import { ControlContainer, FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'tr[app-question-row]',
  standalone: true,
  imports: [
    ReactiveFormsModule
  ],
  templateUrl: './question-row.component.html',
  styleUrl: './question-row.component.scss'
})
export class QuestionRowComponent implements OnInit {
  @Input({ required: true }) question!: Question;
  @Input({ required: true }) formGroupName!: string;
  @Input({ required: true }) isBeforeChecked!: boolean;

  @Input() corectAnswer?: Answer;

  formAnswer!: FormGroup;

  constructor(private controlContainer: ControlContainer) {}

  ngOnInit(): void {
    this.formAnswer = <FormGroup>this.controlContainer.control;
  }
}
