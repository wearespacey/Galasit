import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UnbookComponent } from './unbook.component';

describe('UnbookComponent', () => {
  let component: UnbookComponent;
  let fixture: ComponentFixture<UnbookComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UnbookComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UnbookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
