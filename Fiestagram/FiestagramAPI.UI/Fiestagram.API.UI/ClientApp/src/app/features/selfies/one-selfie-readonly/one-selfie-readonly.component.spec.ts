import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OneSelfieReadonlyComponent } from './one-selfie-readonly.component';

describe('OneSelfieReadonlyComponent', () => {
  let component: OneSelfieReadonlyComponent;
  let fixture: ComponentFixture<OneSelfieReadonlyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OneSelfieReadonlyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OneSelfieReadonlyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
