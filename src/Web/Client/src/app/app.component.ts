import { Component, inject } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { ListOfCountriesComponent } from './country/components/list-of-countries/list-of-countries.component';
import { NgbNav } from '@ng-bootstrap/ng-bootstrap'; 

@Component({
  standalone: true,
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
  imports: [ListOfCountriesComponent, NgbNav]
})
export class AppComponent {
  private router = inject(Router);

  constructor() {
    this.router.navigateByUrl;
  }
}
