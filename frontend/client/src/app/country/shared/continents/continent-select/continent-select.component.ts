import { Component, inject } from '@angular/core';
import { ContinentService } from '../../../services/continent.service';

@Component({
  selector: 'app-continent-select',
  standalone: true,
  imports: [],
  templateUrl: './continent-select.component.html',
  styleUrl: './continent-select.component.scss'
})
export class ContinentSelectComponent {
  private continentServis = inject(ContinentService);
  

}
