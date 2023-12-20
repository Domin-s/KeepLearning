import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NumberOfQuestionsSelectComponent } from './number-of-questions-select.component';

describe('NumberOfQuestionsSelectComponent', () => {
  let component: NumberOfQuestionsSelectComponent;
  let fixture: ComponentFixture<NumberOfQuestionsSelectComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NumberOfQuestionsSelectComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(NumberOfQuestionsSelectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
