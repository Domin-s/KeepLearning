import { Component, OnInit, inject } from '@angular/core';
import { ContinentMapper } from '../../../mappers/continent.mapper';
import { ContinentService } from '../../../services/continent.service';
import { CheckboxListComponent } from '../../../../common/checkbox/components/checkbox-list.component';
import { Checkbox } from '../../../../common/checkbox/model/checkbox';
import { Continent } from '../../../models/Continent';

@Component({
  selector: 'app-continents-checkbox',
  standalone: true,
  imports: [CheckboxListComponent],
  templateUrl: './continents-checkbox.component.html',
  styleUrl: './continents-checkbox.component.scss'
})
export class ContinentsCheckboxComponent implements OnInit { 
  public continentCheckboxes: Checkbox[] = [];

  private continentMapper: ContinentMapper = inject(ContinentMapper);
  private continentService: ContinentService = inject(ContinentService);

  ngOnInit(): void {
    let continents = this.getContinents();
    this.continentCheckboxes = this.continentMapper.mapToCheckbox(continents);
  }

  getContinents(): Continent[] {
    let continents: Continent[] = [];

    this.continentService.getContinents().subscribe({
      next: (result) => {
        continents = result;
      },
      error: (err) => {
        console.log(err);
      }
    })

    return continents;
  }
}
