import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RowCountryComponent } from './row-country.component';

describe('RowCountryComponent', () => {
  let component: RowCountryComponent;
  let fixture: ComponentFixture<RowCountryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [RowCountryComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(RowCountryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
