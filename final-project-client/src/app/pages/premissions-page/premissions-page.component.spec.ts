import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PremissionsPageComponent } from './premissions-page.component';

describe('PremissionsPageComponent', () => {
  let component: PremissionsPageComponent;
  let fixture: ComponentFixture<PremissionsPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PremissionsPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PremissionsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
