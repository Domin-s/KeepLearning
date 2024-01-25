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
  @Input({ required: true }) itemsPerPage!: number;
  
  @Output() setTotalPagesEmit = new EventEmitter<number>();
  @Output() setTotalItemsEmit = new EventEmitter<number>();
  @Output() setCurrentPageEmit = new EventEmitter<number>();
  
  public countries: Country[] = [];
  public pageData: PageData = {
    currentPage: this.currentPage,
    itemsPerPage: this.itemsPerPage,
    totalItems: 1,
    totalPages: 1,
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
    if (changes['itemsPerPage'] !== undefined && !changes['itemsPerPage'].isFirstChange()) {
      this.getCountries();
    }
  }
  
  fiterCountriesByCheckedContientns(): Country[] {
    return this.countries.filter(c => this.continentsChecked.includes(c.continentDto.name));;
  }

  getCountries() {
    this.countryService.getCountries(this.continentsChecked, this.currentPage, this.itemsPerPage).subscribe({
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
      this.setTotalItemsEmit.emit(this.pageData.totalItems);
      this.setCurrentPageEmit.emit(this.pageData.currentPage);
    }
  }

  setCountries(body: any | null) {
    if (body !== null) {
      this.countries = body;
    }
  }
}
