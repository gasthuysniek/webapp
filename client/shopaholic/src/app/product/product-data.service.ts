import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, of, pipe, throwError } from 'rxjs';
import { map, tap, delay, catchError, shareReplay, switchMap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { PRODUCTS } from './mock-product';
import { Product } from './product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductDataService {
  private _reloadProducts$ = new BehaviorSubject<boolean>(true);
  private _products$ = new BehaviorSubject<Product[]>([]);
  private _products : Product[];
  public _productToModify: Product;

  constructor(private http: HttpClient
    ) {
  
this.products$.subscribe((products: Product[])=> {
  this._products = products;
  this._products$.next(this._products);
})

   }

   get allProducts$(): Observable<Product[]>{
     return this._products$;
   }
  get productToModify(): Product{
    return this._productToModify;
  }
  setProductToModify(product: Product){
    this._productToModify = product;
  }

  get products$(): Observable< Product[] > {
    return this.http.get(`${environment.apiUrl}/products/`).pipe(
      shareReplay(1),
        catchError(this.handleError),
        map((list: any[]): Product[] => list.map(Product.fromJSON))
      );
      }
  getProduct$(id: string): Observable<Product>{
    return this.http.get(`${environment.apiUrl}/products/${id}`)
    .pipe(catchError(this.handleError),map(Product.fromJSON));
  }
  getProducts$(){
  return this._reloadProducts$.pipe(
    switchMap(()=>this.products$)
  );
  }
 
  addNewProduct(product: Product)
  {
    return this.http
    .post(`${environment.apiUrl}/products/`, product.toJSON())
    .pipe(catchError(this.handleError), map(Product.fromJSON))
    //observables are cold so nothing happens unless someone subscribes to them
    .subscribe((prod: Product) =>{
      this._products = [...this._products, prod];
    }),
    tap((prod: Product) => {
      this._reloadProducts$.next(true);
    });
  }

  modifyProduct(product: Product)
  {   

    console.log("printing the product we want to modify");
    this._productToModify = new Product("string","string",0,0,"string",true);
    this._productToModify = product; 
    console.log(this._productToModify.toJSON());
    return this.http.put(`${environment.apiUrl}/products/${product.productId}`, this._productToModify.toJSON())
    .pipe(catchError(this.handleError), map(Product.fromJSON))// map(Product.fromJSON))
    //observables are cold so nothing happens unless someone subscribes to them
    /*.subscribe((prod: Product) =>{
      this._products = [...this._products, prod];
    }),
    tap((prod: Product) => {
      this._reloadProducts$.next(true);
    });*/
   /* .subscribe(
    
    })*/
    .subscribe();
  }
  deleteProduct(product: Product) {
    return this.http
      .delete(`${environment.apiUrl}/products/${product.productId}`)
      .pipe(tap(console.log), catchError(this.handleError))
      .subscribe(() => {
        this._reloadProducts$.next(true);
      });
  }
  handleError(err: any): Observable<never>{
    let errorMessage: string;
    if (err.error instanceof ErrorEvent) {
      errorMessage = `An error occurred: ${err.error.message}`;
    }
    else if (err instanceof HttpErrorResponse){
      errorMessage = `'${err.status} ${err.statusText}' when accessing '${err.url}'`;
    }
      else{
      errorMessage = `an unknown error occured ${err}`;
      }
    
    return throwError(errorMessage);
  }
}
