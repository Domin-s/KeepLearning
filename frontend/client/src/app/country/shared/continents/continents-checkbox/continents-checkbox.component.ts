import { Component, Input, OnInit, inject } from '@angular/core';
import { ContinentMapper } from '../../../mappers/continent.mapper';
import { ContinentService } from '../../../services/continent.service';
import { CheckboxListComponent } from '../../../../common/checkbox/components/checkbox-list.component';
import { Checkbox } from '../../../../common/checkbox/model/checkbox';

@Component({
  selector: 'app-continents-checkbox',
  standalone: true,
  imports: [CheckboxListComponent],
  templateUrl: './continents-checkbox.component.html',
  styleUrl: './continents-checkbox.component.scss'
})
export class ContinentsCheckboxComponent implements OnInit { 
  @Input({ required: true }) inOneLine!: boolean;
  @Input({ required: true }) isForm!: boolean;
  public continentCheckboxes: Checkbox[] = [];

  private continentMapper: ContinentMapper = inject(ContinentMapper);
  private continentService: ContinentService = inject(ContinentService);

  ngOnInit(): void {
    this.getContinents();
  }

  getContinents(){
    this.continentService.getContinents().subscribe({
      next: (result) => {
        this.continentCheckboxes = this.continentMapper.mapToCheckbox(result);
      },
      error: (err) => {
        console.log(err);
      }
    })
  }
}
