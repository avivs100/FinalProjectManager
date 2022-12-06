import { TestBed } from '@angular/core/testing';

import { DataProvaiderService } from './data-provaider.service';

describe('DataProvaiderService', () => {
  let service: DataProvaiderService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DataProvaiderService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
