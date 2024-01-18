import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QuestionRowComponent } from './question-row.component';

describe('QuestionTableComponent', () => {
  let component: QuestionRowComponent;
  let fixture: ComponentFixture<QuestionRowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [QuestionRowComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(QuestionRowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
