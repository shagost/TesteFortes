import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { UsersComponent } from './users/users.component';
import { UserDataService } from './_data-services/user.data-service';
import { ProdutosComponent } from './produtos/produtos.component';
import { FornecedoresComponent } from './fornecedores/fornecedores.component';
import { PedidosComponent } from './pedidos/pedidos.component';
import { ItensPedidosComponent } from './itens-pedidos/itens-pedidos.component';
import { ProdutoDataService } from './_data-services/produto.data-services';
import { FornecedorDataService } from './_data-services/fornecedor.data-services';
import { PedidoDataService } from './_data-services/pedido.data-services';
import { ItensPedidoDataService } from './_data-services/itens-pedido.data-services';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    UsersComponent,
    ProdutosComponent,
    FornecedoresComponent,
    PedidosComponent,
    ItensPedidosComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'users', component: UsersComponent },
      { path: 'produtos', component: ProdutosComponent },
      { path: 'fornecedores', component: FornecedoresComponent },
      { path: 'pedidos', component: PedidosComponent },
      { path: 'itens-pedidos', component: ItensPedidosComponent },
      { path: 'itens-pedidos:id', component: ItensPedidosComponent },
    ])
  ],
  providers: [UserDataService, ProdutoDataService, FornecedorDataService, PedidoDataService, ItensPedidoDataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
