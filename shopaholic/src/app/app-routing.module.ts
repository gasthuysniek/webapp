import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ProductListComponent } from './product/product-list/product-list.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { AddProductComponent } from './product/add-product/add-product.component';

import { AuthGuard } from './user/auth.guard';
import { ModifyProductComponent } from './product/modify-product/modify-product.component';
import { OrderComponent } from './order/order/order.component';
import { OrderListComponent } from './order/order-list/order-list.component';


const appRoutes : Routes = [
  {path: 'product/list', component: ProductListComponent},
  {path: 'product/add', 
  canActivate: [AuthGuard],
  component: AddProductComponent},
  {path: 'product/modify/:id', component: ModifyProductComponent},
  {path: 'order/list/user', component: OrderListComponent},
  {path: 'orders/id/:amount', component: OrderComponent},
 
  {path: '', redirectTo: 'login', pathMatch: 'full'},
  {path: '**', component: PageNotFoundComponent}
];

@NgModule({
  imports: [
    RouterModule.forRoot(appRoutes)
  ],
  declarations: [],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
