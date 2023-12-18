import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListOfCountriesComponent } from './list-of-country.component';

describe('ListOfCountriesComponent', () => {
  let component: ListOfCountriesComponent;
  let fixture: ComponentFixture<ListOfCountriesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ListOfCountriesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ListOfCountriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
