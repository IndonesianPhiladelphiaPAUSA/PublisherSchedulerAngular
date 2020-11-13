import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditCapacityComponent } from './add-edit-capacity.component';

describe('AddEditCapacityComponent', () => {
  let component: AddEditCapacityComponent;
  let fixture: ComponentFixture<AddEditCapacityComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddEditCapacityComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditCapacityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
