import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { CountryService } from '../../../services/country.service';
import { Country } from '../../../models/Country';
import { PageData } from '../../../models/PageData';

@Component({
  standalone: true,
  selector: 'app-country-table-component',
  templateUrl: './country-table.component.html',
  styleUrl: './country-table.component.scss',
})
export class CountryTableComponent implements OnInit, OnChanges {
  @Input({ required: true }) continentsChecked!: string[];
  @Input({ required: true }) currentPage!: number;
  
  @Output() setTotalPagesEmit = new EventEmitter<number>();
  @Output() setTotalitemsEmit = new EventEmitter<number>();
  
  public countries: Country[] = [];
  public pageData: PageData = {
    currentPage: this.currentPage,
    itemsPerPage: 20,
    totalItems: 44,
    totalPages: 3,
  };

  constructor(
    private countryService: CountryService,
  ){}

  ngOnInit(): void {
    this.getCountries();
  }
  
  ngOnChanges(changes: SimpleChanges): void {
    if (changes['continentsChecked'] !== undefined && !changes['continentsChecked'].isFirstChange()) {
      this.getCountries();
    }
    if (changes['currentPage'] !== undefined && !changes['currentPage'].isFirstChange()) {
      this.getCountries();
    }
  }
  
  fiterCountriesByCheckedContientns(): Country[] {
    return this.countries.filter(c => this.continentsChecked.includes(c.continentDto.name));;
  }

  getCountries() {
    this.countryService.getCountries(this.continentsChecked, this.currentPage, this.pageData.itemsPerPage).subscribe({
      next: (result) => {
        this.setPageData(result.headers.get('Pagination'));
        this.setCountries(result.body);
      },
      error: (error) => {
        console.log(error);
      }
    })
  }

  setPageData(paginationHeader: string | null) {
    if (paginationHeader !== null) {
      this.pageData = JSON.parse(paginationHeader);
      this.setTotalPagesEmit.emit(this.pageData.totalPages);
      this.setTotalitemsEmit.emit(this.pageData.totalItems);
    }
  }

  setCountries(body: any | null) {
    if (body !== null) {
      this.countries = body;
    }
  }
}
