import { Component, OnInit } from '@angular/core';
import { ItensPedidoDataService } from '../_data-services/itens-pedido.data-services';

@Component({
  selector: 'app-itens-pedidos',
  templateUrl: './itens-pedidos.component.html',
  styleUrls: ['./itens-pedidos.component.css']
})
export class ItensPedidosComponent implements OnInit {

  itens: any[] = [];
  item: any = {};
  showlist: Boolean = true;
  id: any = 1;


  constructor(private itensDataService: ItensPedidoDataService) { }

  ngOnInit() {
    this.get(this.id);
  }

  get(id) {
    this.itensDataService.get(id).subscribe((data: any[]) => {
      this.itens = data;
      this.id = 1;
      this.showlist = true;
    }, error => {
      console.log(error);
      alert('erro interno do sistema');
    });
  }

  post() {
    this.itensDataService.post(this.item).subscribe(data => {
      if (data) {
        alert('Item cadastrado com sucesso');
        this.get(this.id);
        this.item = {};
      } else {
        alert('Erro ao cadastrar item');
      }

    }, error => {
      console.log(error);
      alert('erro interno do sistema');
    });
  }

  openDetails(item) {
    console.log(item);
  }

}
