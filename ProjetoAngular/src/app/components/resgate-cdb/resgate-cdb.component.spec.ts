import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResgateCdbComponent } from './resgate-cdb.component';

describe('ResgateCdbComponent', () => {
  let component: ResgateCdbComponent;
  let fixture: ComponentFixture<ResgateCdbComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ResgateCdbComponent]
    });
    fixture = TestBed.createComponent(ResgateCdbComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
