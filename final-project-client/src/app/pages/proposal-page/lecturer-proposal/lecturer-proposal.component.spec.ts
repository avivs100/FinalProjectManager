import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LecturerProposalComponent } from './lecturer-proposal.component';

describe('LecturerProposalComponent', () => {
  let component: LecturerProposalComponent;
  let fixture: ComponentFixture<LecturerProposalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LecturerProposalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LecturerProposalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
