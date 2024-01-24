import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { CountryService } from '../../../../services/country.service';
import { Country } from '../../../../models/Country';
import { PageData } from '../../../../models/PageData';

@Component({
  standalone: true,
  selector: 'app-country-table-component',
  templateUrl: './country-table.component.html',
  styleUrl: './country-table.component.scss',
})
export class CountryTableComponent implements OnInit, OnChanges {
  @Input({ required: true }) continentsChecked: string[] = [];
  @Input({ required: true }) pageData!: PageData;

  public countries: Country[] = [];

  constructor(
    private countryService: CountryService,
  ){}

  ngOnInit(): void {
    this.getCountries();
  }
  
  ngOnChanges(changes: SimpleChanges): void {
    console.log(changes);
    if (!changes['continentsChecked'].isFirstChange()) {
      console.log(changes);
      this.getCountries();
    }
  }
  
  fiterCountriesByCheckedContientns(): Country[] {
    return this.countries.filter(c => this.continentsChecked.includes(c.continentDto.name));;
  }

  getCountries() {
    console.log(this.continentsChecked, this.pageData.currentPage, this.pageData.itemsPerPage);
    this.countryService.getCountries(this.continentsChecked, this.pageData.currentPage, this.pageData.itemsPerPage).subscribe({
      next: (result) => {
        this.setPageData(result.headers.get('Pagination'));
        this.setCountries(result.body);
        console.log(this.pageData);
        console.log(result.body);
      },
      error: (error) => {
        console.log(error);
      }
    })
  }

  setPageData(paginationHeader: string | null) {
    if (paginationHeader !== null) {
      this.pageData = JSON.parse(paginationHeader);
    }
  }

  setCountries(body: any | null) {
    if (body !== null) {
      this.countries = body;
    }
  }
}
