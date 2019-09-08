import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IncidentesPage } from './incidentes.page';

describe('IncidentesPage', () => {
  let component: IncidentesPage;
  let fixture: ComponentFixture<IncidentesPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IncidentesPage ],
      schemas: [CUSTOM_ELEMENTS_SCHEMA],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IncidentesPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
