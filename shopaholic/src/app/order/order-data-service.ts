import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, of, pipe, throwError } from 'rxjs';
import { map, tap, delay, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Orderline } from '../orderline/orderline.model';
import { Product } from '../product/product.model';
import { Order } from './order.model';


@Injectable({
  providedIn: 'root'
})
export class OrderDataService {
  private _orders$ = new BehaviorSubject<Order[]>([]);
  private _orders : Order[];
  private _currentOrder : Order;
  private _hasOrder : boolean;
  private _orderLine : Orderline;

  constructor(private http: HttpClient) {
    this._hasOrder = false;
this.orders$.subscribe((orders: Order[])=> {
  this._orders = orders;
  this._orders$.next(this._orders);
})

   }

   sethasOrder(){
     this._hasOrder = true;
   }
   setCurrentOrder(order: Order){
     this._currentOrder = order;
   }

   get orderLine(): Orderline{
     return this._orderLine;
   }

  get currentOrder(): Order{
    return this._currentOrder;
  }

  /* get allOrders$(): Observable<Order[]>{
     return this.orders$;
   }*/

   get hasOrder(): boolean{
     return this._hasOrder;
   }

  get orders$(): Observable< Order[] > {
    
    return this.http.get(`${environment.apiUrl}/Orders?userid=-1`).pipe(
      
        catchError(this.handleError),
        map((list: any[]): Order[] => list.map(Order.fromJson))
      );
      }

      
  getOrder$(id: string): Observable<Order>{
    return this.http.get(`${environment.apiUrl}/orders/${id}`)
    .pipe(catchError(this.handleError),map(Order.fromJson));
  }
  
  addNewOrder(order:Order)
  {
   /* console.log("line before post request in addneworder");
    console.log(order);
    */
    return this.http
    .post(`${environment.apiUrl}/orders/`, order.toJSONAdd())
    .pipe(catchError(this.handleError), map(Order.fromJson))
    //observables are cold so nothing happens unless someone subscribes to them
    .subscribe((ord: Order) =>{
      this._orders = [...this._orders, ord];
      this._currentOrder = ord;
      this.setCurrentOrder(ord);
      this.sethasOrder();
    });
  }
//put request
  addProductToOrder( orderId :number, productId : number, amount: number){
    console.log("PRINTING THE ORDERID");
    console.log(orderId);
    this._orderLine = new Orderline(orderId,productId,amount);
    console.log("printing current order");
    console.log(this.currentOrder);
    return this.http.put(`${environment.apiUrl}/orders/${orderId}/${amount}`,this._orderLine.toJSON())
    .pipe(catchError(this.handleError)).subscribe();
    //, map(Orderline.fromJson));
    //.subscribe()
    /*resp => {
      console.log("printing response in pipe");
      console.log(resp);
    })*/
  }

  deleteOrder(orderid: number){
    return this.http
    .delete(`${environment.apiUrl}/Orders/${orderid}`)
    .pipe(tap(console.log), catchError(this.handleError))
    .subscribe();
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
