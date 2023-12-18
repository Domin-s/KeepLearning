import { Component, OnInit, inject } from '@angular/core';
import { CheckboxListComponent } from '../../common/checkbox.components/checkbox-list/checkbox-list.component';
import { Checkbox } from '../../common/checkbox.components/model/checkbox';
import { ContinentService } from '../services/continent.service';
import { ContinentMapper } from '../mapper/continent.mapper';

@Component({
  selector: 'app-continents-checkbox',
  standalone: true,
  imports: [CheckboxListComponent],
  templateUrl: './continents-checkbox.component.html',
  styleUrl: './continents-checkbox.component.scss'
})
export class ContinentsCheckboxComponent implements OnInit {
  public continents: Checkbox[] = [];

  private continentMapper: ContinentMapper = inject(ContinentMapper);
  private continentService: ContinentService = inject(ContinentService);

  ngOnInit(): void {
    this.getContinents();
  }

  getContinents() {
    this.continentService.getContinents().subscribe({
      next: (result) => {
        this.continents = this.continentMapper.mapToCheckbox(result);
      },
      error: (err) => {
        console.log(err);
        this.continents = [];
      }
    })
  }
}
