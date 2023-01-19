import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SessionEditPageComponent } from './session-edit-page.component';

describe('SessionEditPageComponent', () => {
  let component: SessionEditPageComponent;
  let fixture: ComponentFixture<SessionEditPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SessionEditPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SessionEditPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
