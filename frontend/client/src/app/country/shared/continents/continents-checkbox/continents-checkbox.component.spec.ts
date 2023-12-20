import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContinentsCheckboxComponent } from './continents-checkbox.component';

describe('ContinentsCheckboxComponent', () => {
  let component: ContinentsCheckboxComponent;
  let fixture: ComponentFixture<ContinentsCheckboxComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ContinentsCheckboxComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ContinentsCheckboxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
