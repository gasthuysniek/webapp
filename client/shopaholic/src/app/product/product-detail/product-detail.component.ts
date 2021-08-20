import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductDataService } from '../product-data.service';
import { Product } from '../product.model';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {
public product: Product;
  constructor(
private route: ActivatedRoute,
private productDataService: ProductDataService

  ) { }

  ngOnInit() {
    this.route.data.subscribe(item => (this.product = item['product']));
  }

}
