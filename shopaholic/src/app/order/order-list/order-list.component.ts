import { Component, OnInit } from '@angular/core';
import { EMPTY, Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { OrderDataService } from '../order-data-service';
import { Order } from '../order.model';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css']
})
export class OrderListComponent implements OnInit {
  private _fetchOrders$: Observable<Order[]>

  public loading: boolean;
  public errorMessage: string = '';

  constructor(private _orderDataService: OrderDataService) { }

  ngOnInit(): void {
    console.log("ngoniti in orderlistcomponent");
    this._fetchOrders$ = this._orderDataService.orders$.pipe(
      catchError(err =>{
        this.errorMessage = err;
        this.loading = true;
        return EMPTY;
      }),
      
    );
    this.orders$.subscribe(orders => console.log(orders));
    
  }
  
  get orders$(): Observable<Order[]>{
    return this._fetchOrders$;
  }

  addNewOrder( order: Order){
    this._orderDataService.addNewOrder(order);
  }
  deleteOrder(orderid: number){
    this._orderDataService.deleteOrder(orderid);
   }
 

}
