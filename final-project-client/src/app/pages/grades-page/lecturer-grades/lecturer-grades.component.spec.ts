import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LecturerGradesComponent } from './lecturer-grades.component';

describe('LecturerGradesComponent', () => {
  let component: LecturerGradesComponent;
  let fixture: ComponentFixture<LecturerGradesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LecturerGradesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LecturerGradesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
