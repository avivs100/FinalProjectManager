import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DayInScheduleDetailsComponent } from './day-in-schedule-details.component';

describe('DayInScheduleDetailsComponent', () => {
  let component: DayInScheduleDetailsComponent;
  let fixture: ComponentFixture<DayInScheduleDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DayInScheduleDetailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DayInScheduleDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
