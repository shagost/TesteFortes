import { Component, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';
import { FornecedorDataService } from '../_data-services/fornecedor.data-services';
import { ItensPedidoDataService } from '../_data-services/itens-pedido.data-services';
import { PedidoDataService } from '../_data-services/pedido.data-services';
import { ProdutoDataService } from '../_data-services/produto.data-services';

@Component({
  selector: 'app-pedidos',
  templateUrl: './pedidos.component.html',
  styleUrls: ['./pedidos.component.css']
})
export class PedidosComponent implements OnInit {

  pedidos: any[] = [];
  pedido: any = {};
  showlist: Boolean = true;
  fornecedores: any[] = [];
  itens: any[] = [];
  includeItem: Boolean = false;
  produtos: any[] = [];
  produto: any = {};

  constructor(private pedidoDataService: PedidoDataService, private fornecedorDataService: FornecedorDataService,
    private itensDataService: ItensPedidoDataService, private produtoDataService: ProdutoDataService, private router: Router) {
    this.getFornecedores();
    this.getProdutos();
  }

  ngOnInit() {
    this.get();
  }

  getFornecedores() {
    this.fornecedorDataService.get().subscribe((data: any[]) => {
      this.fornecedores = data;
    });
  }

  getProdutos() {
    this.produtoDataService.get().subscribe((data: any[]) => {
      this.produtos = data;
    });
  }

  getItens() {
    this.itensDataService.get(this.pedido.pedidoId).subscribe((data: any[]) => {
      this.itens = data;
    });
  }

  get() {
    this.pedidoDataService.get().subscribe((data: any[]) => {
      this.pedidos = data;
      this.showlist = true;
      this.includeItem = false;
    }, error => {
      console.log(error);
      alert('erro interno do sistema');
    });
  }

  post() {
    console.log(this.pedido);
    this.pedidoDataService.post(this.pedido).subscribe(data => {
      console.log(this.pedido);
      if (data) {
        alert('Pedido cadastrado com sucesso');
        this.get();
        this.pedido = {};
      } else {
        alert('Erro ao cadastrar pedido');
      }

    }, error => {
      console.log(error);
      alert('erro interno do sistema');
    });
  }

  openDetails(pedido) {
    this.showlist = false;
    this.pedido = pedido;
    this.includeItem = true;
    this.itensDataService.get(pedido.pedidoId).subscribe(data => {
      if (data) {
        this.itens = data;
      }
      else {
        alert('Nop');
      }
    })
  }

  incluirItem(produto) {
    const first = this.produtos.find((obj) => {
      return obj.produtoId == produto.produtoId;
    });
    const item = {
      pedidoId: this.pedido.pedidoId, produtoId: produto.produtoId,
      quantidade: produto.quantidade, valorUnitario: first.valor
    };
    this.itensDataService.post(item).subscribe((data: any[]) => {
      if (data) {
        alert('Item cadastrado com sucesso');
        this.getItens();
      } else {
        alert('Erro ao cadastrar item');
      }
    });
    this.includeItem = false;
  }


}
