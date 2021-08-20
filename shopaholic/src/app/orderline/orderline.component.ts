import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductDataService } from '../product/product-data.service';
import { Product } from '../product/product.model';
import { Orderline } from './orderline.model';

@Component({
  selector: 'app-orderline',
  templateUrl: './orderline.component.html',
  styleUrls: ['./orderline.component.css']
})
export class OrderlineComponent implements OnInit {
  @Input() public orderLine: Orderline;
  @Input() public product: Product

  constructor(private _productdataservice: ProductDataService
   
    ) {  this.orderLine = new Orderline(0,0,0);
    //this.orderLine.setProduct (new Product("","",0,0,"",false));
      
  }

  ngOnInit(): void {  
    //setting initial values 
     this.orderLine.setProduct (new Product("","",0,0,"",false));  
  /* this.product = {
     productId : 0,
     productClass : "",
     productName : "",
     description : "",

   }*/

   this._productdataservice.getProduct$(this.orderLine.productId.toString()).subscribe(prod => {
   
     this.orderLine.setProduct(prod);
     console.log("printing product from productline");
     console.log(this.product);
     console.log("printing orderline");
     console.log(this.orderLine);
    });
 
  }



  

}
