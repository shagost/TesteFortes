import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ItensPedidosComponent } from './itens-pedidos.component';

describe('ItensPedidosComponent', () => {
  let component: ItensPedidosComponent;
  let fixture: ComponentFixture<ItensPedidosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ItensPedidosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ItensPedidosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
