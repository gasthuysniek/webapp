import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { OrderDataService } from 'src/app/order/order-data-service';
import { Order } from 'src/app/order/order.model';
import { ProductDataService } from '../product-data.service';
import { Product } from '../product.model';


@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
   @Input() public product: Product;
  

  constructor(private _productDataService: ProductDataService,
    private _orderDataService: OrderDataService,
    private _router: Router) {}
 
  ngOnInit(): void {

  } 
  deleteProduct() {
    console.log(this.product);
    
    this._productDataService.deleteProduct(this.product);
    //window.location.reload();
  }
  modifyProduct()
  {
   // this._router.navigate(['/product/modify/:id']);
   console.log("line in modifyproduct");
   console.log(this.product);
   this._productDataService.setProductToModify(this.product);
   this._router.navigate([`/product/modify/${this.product.productId}`]);
  }
  addProductToOrder()
  {
    console.log("PRINTING IN ADDPRODUCTTOORDER")
    console.log(this._orderDataService.currentOrder);
    /*if(!this._orderDataService.currentOrder.active)
    {
      this._orderDataService.addNewOrder(new Order(0,true,[],new Date(),0));
    }*/
    this._router.navigate([`order/${this.product.productId}`]);
    /*
    setting the initial value
    
    */
   

  }
  retrieveProduct(): Product{
    return this.product;
  }
  

 
}
