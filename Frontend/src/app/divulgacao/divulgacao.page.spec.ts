import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DivulgacaoPage } from './divulgacao.page';

describe('DivulgacaoPage', () => {
  let component: DivulgacaoPage;
  let fixture: ComponentFixture<DivulgacaoPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DivulgacaoPage ],
      schemas: [CUSTOM_ELEMENTS_SCHEMA],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DivulgacaoPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
