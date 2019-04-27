import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SeatInfoComponentComponent } from './seat-info-component.component';

describe('SeatInfoComponentComponent', () => {
  let component: SeatInfoComponentComponent;
  let fixture: ComponentFixture<SeatInfoComponentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SeatInfoComponentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SeatInfoComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
