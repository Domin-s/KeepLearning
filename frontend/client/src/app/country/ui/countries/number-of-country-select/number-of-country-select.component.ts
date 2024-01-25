import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-number-of-country-select',
  standalone: true,
  imports: [],
  templateUrl: './number-of-country-select.component.html',
})
export class NumberOfCountrySelectComponent implements OnInit, OnChanges {
  @Input({ required: true }) totalItems!: number;

  @Output() setItemsPerPageEmit = new EventEmitter<number>();

  private numbersOfItem = [10, 20, 50, 100];

  public itemsOnPage: number[] = [];
  public selectedItemOnPage: number = 10;

  ngOnInit(): void {
    this.itemsOnPage = this.getNumbersOfCountries(this.totalItems, this.numbersOfItem);
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['totalItems'] !== undefined && !changes['totalItems'].isFirstChange()) {
      this.itemsOnPage = this.getNumbersOfCountries(this.totalItems, this.numbersOfItem);
    }
  }  

  getNumbersOfCountries(maxNumber: number, numbersToChoose: number[]): number[] {
    let numbers: number[] = [];

    for (let i = 0; i < numbersToChoose.length; i++) {
      const element = numbersToChoose[i];
      if(element <= maxNumber) {
        numbers.push(element);
      } else {
        break;
      }
    }

    return numbers;
  }

  onSelect(event: Event){
    this.selectedItemOnPage = parseInt((event.target as HTMLSelectElement).value);
    this.setItemsPerPageEmit.emit(this.selectedItemOnPage);
  }
}
