import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-pagination',
  standalone: true,
  imports: [],
  templateUrl: './pagination.component.html'
})
export class PaginationComponent implements OnInit, OnChanges {
  @Input({ required: true }) totalPages!: number;
  @Input({ required: true }) currentPage!: number;
  @Input({ required: true }) totalItems!: number;

  @Output() setCurrentPageEmit = new EventEmitter<number>();

  public numberOfPages: number[] = [];
  public isStartPage: boolean = true;
  public nextDisabled = false;
  public previousDisabled = true;

  ngOnInit(): void {
    this.numberOfPages = this.getNumberOfPages(this.totalPages);
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['totalPages'] !== undefined && !changes['totalPages'].isFirstChange()) {
      this.numberOfPages = this.getNumberOfPages(this.totalPages);
    }
    if (changes['totalItems'] !== undefined && !changes['totalItems'].isFirstChange()) {
      this.numberOfPages = this.getNumberOfPages(this.totalPages);
    }
  }  

  getNumberOfPages(totalPages: number) {
    let number: number[] = [];
    for (let i = 1; i <= totalPages; i++) {
      number.push(i);
    }

    return number;
  }

  onSubmitPrevious(){
    this.currentPage = this.currentPage - 1;
    this.setCurrentPageEmit.emit(this.currentPage);
    this.setDisabledButton();
  }

  onSubmitPage(pageNumber: number){
    this.currentPage = pageNumber;
    this.setCurrentPageEmit.emit(this.currentPage);
    this.setDisabledButton();
  }

  onSubmitNext(){
    this.currentPage = this.currentPage + 1;
    this.setCurrentPageEmit.emit(this.currentPage);
    this.setDisabledButton();
  }

  setDisabledButton(){
    this.setDisabledPrevoiusButton();
    this.setDisabledNextButton();
    this.isStartPage = false;
  }

  setDisabledPrevoiusButton(){
    if (this.currentPage === 1) {
      this.previousDisabled = true;
    } else {
      this.previousDisabled = false;
    }
  }

  setDisabledNextButton(){
    if (this.currentPage >= this.totalPages){
      this.nextDisabled = true;
    } else {
      this.nextDisabled = false;
    }
  }

  showButton(numberOfPage: number): boolean {
    if(numberOfPage < this.currentPage - 1 || numberOfPage > this.currentPage + 1 ){
      return false;
    }

    return true;
  }
}
