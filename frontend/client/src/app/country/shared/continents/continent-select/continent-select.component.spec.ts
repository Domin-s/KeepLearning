import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContinentSelectComponent } from './continent-select.component';

describe('ContinentSelectComponent', () => {
  let component: ContinentSelectComponent;
  let fixture: ComponentFixture<ContinentSelectComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ContinentSelectComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ContinentSelectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
