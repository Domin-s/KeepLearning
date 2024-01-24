import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { PageData } from '../../../models/PageData';

@Component({
  selector: 'app-pagination',
  standalone: true,
  imports: [],
  templateUrl: './pagination.component.html',
  styleUrl: './pagination.component.scss'
})
export class PaginationComponent implements OnInit {
  @Input({ required: true }) pageData!: PageData;

  @Output() setPageDataEmit = new EventEmitter<PageData>();

  public numberOfPages: number[] = [];
  // public currentPage: number = 1;
  public nextDisabled = true;
  public previousDisabled = true;

  ngOnInit(): void {
    this.configurePaginationData();
  }

  configurePaginationData(){
    this.numberOfPages = this.getNumberOfPages(this.pageData.totalPages);
    this.pageData.currentPage = this.pageData.currentPage;
    this.previousDisabled = this.pageData.currentPage === 1;
    this.nextDisabled = this.pageData.currentPage === this.pageData.totalPages;
  }

  getNumberOfPages(totalPages: number) {
    let number: number[] = [];
    for (let i = 1; i <= totalPages; i++) {
      number.push(i);
    }

    return number;
  }

  onSubmitPrevious(){
    this.pageData.currentPage = this.pageData.currentPage - 1;
    this.setPageDataEmit.emit(this.pageData);
    this.setDisabledButton();
  }

  onSubmitPage(pageNumber: number){
    this.pageData.currentPage = pageNumber;
    this.setPageDataEmit.emit(this.pageData);
    this.setDisabledButton();
  }

  onSubmitNext(){
    this.pageData.currentPage = this.pageData.currentPage + 1;
    this.setPageDataEmit.emit(this.pageData);
    this.setDisabledButton();
  }

  setDisabledButton(){
    this.setDisabledPrevoiusButton();
    this.setDisabledNextButton();
    console.log(this.pageData.currentPage);
  }

  setDisabledPrevoiusButton(){
    if (this.pageData.currentPage === 1) {
      this.previousDisabled = true;
    } else {
      this.previousDisabled = false;
    }
  }

  setDisabledNextButton(){
    if (this.pageData.currentPage >= this.pageData.totalPages){
      this.nextDisabled = true;
    } else {
      this.nextDisabled = false;
    }
  }

}
