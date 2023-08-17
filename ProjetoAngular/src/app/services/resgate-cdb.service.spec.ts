import { TestBed } from '@angular/core/testing';

import { ResgateCdbService } from './resgate-cdb.service';

describe('ResgateCdbService', () => {
  let service: ResgateCdbService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ResgateCdbService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
