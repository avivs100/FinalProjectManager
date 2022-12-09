import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LecturerSubmissionsComponent } from './lecturer-submissions.component';

describe('LecturerSubmissionsComponent', () => {
  let component: LecturerSubmissionsComponent;
  let fixture: ComponentFixture<LecturerSubmissionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LecturerSubmissionsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LecturerSubmissionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
