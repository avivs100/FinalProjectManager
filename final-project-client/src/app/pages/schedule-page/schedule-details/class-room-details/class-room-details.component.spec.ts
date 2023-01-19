import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClassRoomDetailsComponent } from './class-room-details.component';

describe('ClassRoomDetailsComponent', () => {
  let component: ClassRoomDetailsComponent;
  let fixture: ComponentFixture<ClassRoomDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClassRoomDetailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClassRoomDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
