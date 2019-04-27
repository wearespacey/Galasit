import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UnbookComponentComponent } from './unbook-component.component';

describe('UnbookComponentComponent', () => {
  let component: UnbookComponentComponent;
  let fixture: ComponentFixture<UnbookComponentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UnbookComponentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UnbookComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
