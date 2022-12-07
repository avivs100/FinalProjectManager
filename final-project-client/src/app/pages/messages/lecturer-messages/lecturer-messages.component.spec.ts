import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LecturerMessagesComponent } from './lecturer-messages.component';

describe('LecturerMessagesComponent', () => {
  let component: LecturerMessagesComponent;
  let fixture: ComponentFixture<LecturerMessagesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LecturerMessagesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LecturerMessagesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
