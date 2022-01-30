import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SelfiesListComponent } from './selfies-list.component';

describe('SelfiesListComponent', () => {
  let component: SelfiesListComponent;
  let fixture: ComponentFixture<SelfiesListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SelfiesListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SelfiesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
