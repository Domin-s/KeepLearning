import { Component, OnInit, inject } from '@angular/core';
import { CheckboxListComponent } from '../../common/checkbox.components/checkbox-list/checkbox-list.component';
import { Checkbox } from '../../common/checkbox.components/model/checkbox';
import { HttpClient } from '@angular/common/http';
import { Continent } from '../../country/models/Continent';

@Component({
  selector: 'app-continents-checkbox',
  standalone: true,
  imports: [CheckboxListComponent],
  templateUrl: './continents-checkbox.component.html',
  styleUrl: './continents-checkbox.component.scss'
})
export class ContinentsCheckboxComponent implements OnInit {
  public continents: Checkbox[] = [];

  private http: HttpClient = inject(HttpClient);

  ngOnInit(): void {
    this.getContinents();
  }

  getContinents() {
    this.http.get<Continent[]>('https://localhost:5001/api/Continent').subscribe({
      next: (result) => this.mapToCheckbox(result),
      error: (error) => console.log(error)
  })}

  mapToCheckbox(continents: Continent[]) {
    for (let i = 0; i < continents.length; i++) {
      const continent = continents[i];

      let checkbox: Checkbox  = new Checkbox(
        continent.name,
        "Continent",
        continent.name,
        true
      );
      
      this.continents.concat(checkbox);
    }
  }
}
