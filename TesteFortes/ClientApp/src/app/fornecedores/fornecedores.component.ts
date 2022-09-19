import { Component, OnInit } from '@angular/core';
import { FornecedorDataService } from '../_data-services/fornecedor.data-services';

@Component({
  selector: 'app-fornecedores',
  templateUrl: './fornecedores.component.html',
  styleUrls: ['./fornecedores.component.css']
})
export class FornecedoresComponent implements OnInit {

  fornecedores: any[] = [];
  fornecedor: any = {};
  showlist: Boolean = true;

  constructor(private fornecedorDataService: FornecedorDataService) { }

  ngOnInit() {
    this.get();
  }

  get() {
    this.fornecedorDataService.get().subscribe((data: any[]) => {
      this.fornecedores = data;
      this.showlist = true;
    }, error => {
      console.log(error);
      alert('erro interno do sistema');
    });
  }

  save() {
    console.log(this.fornecedor);
    if (this.fornecedor.fornecedorId) {
      this.put();
    }
    else {
      this.post();
    }
  }

  post() {
    this.fornecedorDataService.post(this.fornecedor).subscribe(data => {
      if (data) {
        alert('Fornecedor cadastrado com sucesso');
        this.get();
        this.fornecedor = {};
      } else {
        alert('Erro ao cadastrar fornecedor');
      }

    }, error => {
      console.log(error);
      alert('erro interno do sistema');
    });
  }

  put() {
    this.fornecedorDataService.put(this.fornecedor).subscribe(data => {
      if (data) {
        alert('Fornecedor atualizado com sucesso');
        this.get();
        this.fornecedor = {};
      } else {
        alert('Erro ao atualizar fornecedor');
      }

    }, error => {
      console.log(error);
      alert('erro interno do sistema');
    });
  }

  openDetails(fornecedor) {
    console.log(fornecedor);
    this.showlist = false;
    this.fornecedor = fornecedor;
  }

  delete(fornecedor){
    this.fornecedorDataService.delete(fornecedor.fornecedorId).subscribe(data => {
      if(data){
        alert('Fornecedor excluído com sucesso.');
        this.get();
        this.fornecedor = {};
      }
      else{
        alert('Não é possível excluir o fornecedor. Verifique se tem pedido dele.');
      }
    }, error => {
      console.log(error);
      alert('erro interno do sistema');
    });
  }

}
