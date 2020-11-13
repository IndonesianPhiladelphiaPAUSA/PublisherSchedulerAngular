import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowCapacityComponent } from './show-capacity.component';

describe('ShowCapacityComponent', () => {
  let component: ShowCapacityComponent;
  let fixture: ComponentFixture<ShowCapacityComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ShowCapacityComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowCapacityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
