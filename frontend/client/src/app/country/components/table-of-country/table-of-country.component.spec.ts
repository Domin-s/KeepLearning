import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TableOfCountriesComponent } from './table-of-country.component';

describe('TableOfCountriesComponent', () => {
  let component: TableOfCountriesComponent;
  let fixture: ComponentFixture<TableOfCountriesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TableOfCountriesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TableOfCountriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
