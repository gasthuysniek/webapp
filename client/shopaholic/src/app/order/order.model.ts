import { Orderline, OrderLineJson } from "../orderline/orderline.model";

export interface OrderJson{
    id: number;
    userId: number;
    active: boolean;
    orderLines: OrderLineJson[];
    creationDate: string;
    orderTotaal: number;
}
export interface OrderJsonAdd{  
  orderLines: OrderLineJson[]; 
}
/*interface OrderJsonPut{  
  
  /*"productClass": "string",
  "productName": "string",
  "unitPrice": 0,
  "availability": 0,
  "description": "string"
  
  orderLines: OrderLineJson[]; 
}*/

export class Order {
    private _id: number;
    constructor(
    private _userId: number,
    private _active: boolean,
    private _orderLines = new Array<Orderline>(),
    private _creationDate = new Date(),
    private _orderTotaal: number //float in db

    ) {}
 static fromJson(json: OrderJson): Order{
    const order = new Order(
      json.userId,
       json.active,
       json.orderLines.map(Orderline.fromJson)
       ,new Date(json.creationDate), json.orderTotaal);
    order._id = json.id;
       return order;
 }   

  toJSON(): OrderJson {
    return <OrderJson>{  
      id: this.id,    
      userId: this.userId,
      active: this.active,
      creationDate: this.creationDate.toString(),
      orderTotaal: this.orderTotaal     
    };
    
  }
  toJSONAdd(): OrderJsonAdd {
    return <OrderJsonAdd>{  
      orderLines : this.orderLines,
    };
  }

  /*toJSONPut(): OrderJsonPut{
    return <OrderJsonPut>{

    }
  }*/




    get userId(): number{
        return this._userId;
    }

    get active(): boolean{
        return this._active;
    }

    get creationDate(): Date{
        return this._creationDate;
    }

    get orderTotaal(): number{
        return this._orderTotaal;
    }

    get id(): number{
      return this._id;
    }

    get orderLines(): Orderline[]{
      return this._orderLines;
    }

    addOrderline(productid: number, quantity: number)
    {
      this._orderLines.push(new Orderline(0,productid, quantity));
    }
    setId(id: number){
      this._id = id;
    }
    
  }