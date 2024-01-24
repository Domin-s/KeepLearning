import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-pagination',
  standalone: true,
  imports: [],
  templateUrl: './pagination.component.html',
  styleUrl: './pagination.component.scss'
})
export class PaginationComponent implements OnInit, OnChanges {
  @Input({ required: true }) totalPages!: number;
  @Input({ required: true }) currentPage!: number;

  @Output() setCurrentPageEmit = new EventEmitter<number>();

  public numberOfPages: number[] = [];
  public pagesToShow: number[] = [1, 2, 3];
  public nextDisabled = true;
  public previousDisabled = true;

  ngOnInit(): void {
    this.configurePaginationData();
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['totalPages'] !== undefined && !changes['totalPages'].isFirstChange()) {
      this.numberOfPages = this.getNumberOfPages(this.totalPages);
    }
  }  

  configurePaginationData(){
    this.numberOfPages = this.getNumberOfPages(this.totalPages);
    this.currentPage = this.currentPage;
    this.previousDisabled = this.currentPage === 1;
    this.nextDisabled = this.currentPage === this.totalPages;
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
