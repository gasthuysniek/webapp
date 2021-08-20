import { Component, OnInit } from '@angular/core';
import { Subject, EMPTY } from 'rxjs';
import { PRODUCTS } from '../mock-product';
import{distinctUntilChanged, debounceTime,map,filter, catchError, switchMap} from 'rxjs/operators'
import { ProductDataService } from '../product-data.service';
import { Product } from '../product.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  private _fetchProducts$: Observable<Product[]>// = this._productDataService.products$; 
  public loading: boolean;
  public filterProductName: string;
  //storing the filter in an observable
  public filterProduct$ = new Subject<string>();
  public errorMessage: string = '';
  constructor(private _productDataService: ProductDataService) { 
    //subscribe to act on the values fired from the observable
/*this._productDataService.products$.subscribe(
  res => this._products = res*/


    this.filterProduct$
    .pipe(distinctUntilChanged(),
    debounceTime(400),
    map(val => val.toLowerCase())    
    )
    .subscribe(
      val => this.filterProductName = val);

  }
 
  ngOnInit(): void {
    this._fetchProducts$ = this._productDataService.allProducts$.pipe(
      catchError(err => {
        this.errorMessage = err;
        this.loading = true;
        return EMPTY;
      })
      
    );
    
  }
  applyFilter(filter:string)
  {
    this.filterProductName = filter;
  }
  get products$(): Observable<Product[]>{
    return this._fetchProducts$;
  }
  addNewProduct(product: Product)
  {
    this._productDataService.addNewProduct(product);
  
  }

}