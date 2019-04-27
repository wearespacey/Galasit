import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BubbleComponentComponent } from './bubble-component.component';

describe('BubbleComponentComponent', () => {
  let component: BubbleComponentComponent;
  let fixture: ComponentFixture<BubbleComponentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BubbleComponentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BubbleComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
