import { Component, OnInit, Output } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { PreviousRouteService } from '../../../services/previousRoute.service';
import { GenerateExamForm } from '../../../forms/generateExam.form';
import { ContinentsCheckboxComponent } from '../../../shared/continents/continents-checkbox/continents-checkbox.component';
import { CountryTableComponent } from './country-table/country-table.component';
import { PaginationComponent } from '../pagination/pagination.component';
import { PageData } from '../../../models/PageData';

@Component({
  standalone: true,
  selector: 'app-list-of-countries',
  templateUrl: './list-of-country.component.html',
  styleUrl: './list-of-country.component.scss',
  imports: [
    CountryTableComponent,
    ContinentsCheckboxComponent,
    PaginationComponent,
    RouterLink
  ],
  providers: [GenerateExamForm],
})
export class ListOfCountriesComponent implements OnInit {
  @Output() continentsChecked: string[] = ['Africa', 'Asia', 'Australia', 'Europe', 'North America', 'South America'];
  @Output() pageNumber: number = 1;
  @Output() pageSize: number = 10;

  public pageData: PageData = {
    currentPage: 1,
    itemsPerPage: 10,
    totalItems: 44,
    totalPages: 5
  };

  previousUrl: string = '';
  currentUrl: string = '';

  constructor(
    private route: ActivatedRoute,
    private previousRouteService: PreviousRouteService
  ) {
  }
  
  ngOnInit(): void {
    this.previousUrl = this.previousRouteService.getPreviousUrl();
    this.continentsChecked = this.setCheckedContinentByDefault();
  }

  getCheckedContinents(continents: string[]){
    this.continentsChecked = continents;
  }

  getContinentsFromPath(){
    let continentsFromPath: string[] = [];
    
    this.route.queryParamMap.subscribe( params => {
      continentsFromPath = params.getAll('continentsChecked');
    });

    return continentsFromPath;
  }

  setCheckedContinentByDefault(): string[]{
    if (this.previousUrl.includes('/country/generateExam')) {
      return this.getContinentsFromPath();
    }

    return this.continentsChecked;
  }

  setPageData(pageData: PageData) {
    this.pageData = pageData;
    console.log("ListOfCountriesComponent => setPageData(pageData: PageData)");
    console.log(this.pageData);
  }
}
