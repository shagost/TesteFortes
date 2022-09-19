import { Component, OnInit } from '@angular/core';
import { ProdutoDataService } from '../_data-services/produto.data-services';

@Component({
  selector: 'app-produtos',
  templateUrl: './produtos.component.html',
  styleUrls: ['./produtos.component.css']
})
export class ProdutosComponent implements OnInit {

  produtos: any[] = [];
  produto: any = {};
  showlist: Boolean = true;

  constructor(private produtoDataService: ProdutoDataService) { }

  ngOnInit() {
    this.get();
  }

  get() {
    this.produtoDataService.get().subscribe((data: any[]) => {
      this.produtos = data;
      this.showlist = true;
    }, error => {
      console.log(error);
      alert('erro interno do sistema');
    });
  }

  save() {
    console.log(this.produto);
    if (this.produto.produtoId) {
      this.put();
    }
    else {
      this.post();
    }
  }

  post() {
    this.produtoDataService.post(this.produto).subscribe(data => {
      if (data) {
        alert('Produto cadastrado com sucesso');
        this.get();
        this.produto = {};
      } else {
        alert('Erro ao cadastrar produto');
      }

    }, error => {
      console.log(error);
      alert('erro interno do sistema');
    });
  }

  put() {
    this.produtoDataService.put(this.produto).subscribe(data => {
      if (data) {
        alert('Produto atualizado com sucesso');
        this.get();
        this.produto = {};
      } else {
        alert('Erro ao atualizar produto');
      }

    }, error => {
      console.log(error);
      alert('erro interno do sistema');
    });
  }

  openDetails(produto) {
    console.log(produto);
    this.showlist = false;
    this.produto = produto;
  }

  delete(produto){
    this.produtoDataService.delete(produto.produtoId).subscribe(data => {
      if(data){
        alert('Produto excluído com sucesso.')
        this.get();
        this.produto = {};
      }
      else{
        alert('Não é possível excluir o produto. Verifique se tem pedido dele.');
      }
    }, error => {
      console.log(error);
      alert('erro interno do sistema');
    });
  }

}

