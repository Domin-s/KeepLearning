import { Component, Input } from '@angular/core';
import { UserAnswer } from '../../../../models/UserAnswer';

@Component({
  selector: 'app-answer-history',
  standalone: true,
  imports: [],
  templateUrl: './answer-history.component.html',
  styleUrl: './answer-history.component.scss'
})
export class AnswerHistoryComponent {
  @Input() answerHistory: UserAnswer[] = [];
}
