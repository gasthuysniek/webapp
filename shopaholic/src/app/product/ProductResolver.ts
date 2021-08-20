import { Injectable } from '@angular/core';
import {
    Resolve,
    RouterStateSnapshot,
    ActivatedRouteSnapshot
  } from '@angular/router';
import { Observable } from 'rxjs';
import { ProductDataService } from './product-data.service';
  import { Product} from './product.model';

  
  @Injectable({
    providedIn: 'root'
  })
  export class ProductResolver implements Resolve<Product> {
    constructor(private productService: ProductDataService) {}
  
    resolve(
      route: ActivatedRouteSnapshot,
      state: RouterStateSnapshot
    ): Observable<Product> {
      return this.productService.getProduct$(route.params['id']);
    }
  }
  