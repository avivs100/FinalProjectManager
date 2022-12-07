import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LecturerProjectsComponent } from './lecturer-projects.component';

describe('LecturerProjectsComponent', () => {
  let component: LecturerProjectsComponent;
  let fixture: ComponentFixture<LecturerProjectsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LecturerProjectsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LecturerProjectsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
