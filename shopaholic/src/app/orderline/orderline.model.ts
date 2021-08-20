import { Product } from "../product/product.model";

export interface OrderLineJson{
    orderId: number;
    productId: number;
    quantity: number;
}



export class Orderline{
    //private _orderId: number;
    private _product: Product;
    constructor(
    private _orderId: number,
    private _productId: number,
    private _quantity: number,
  

    ){}

static fromJson(json: OrderLineJson): Orderline{
    const orderLine = new Orderline(json.orderId, json.productId, json.quantity);
    return orderLine;
}

    toJSON(): OrderLineJson{
        return {orderId: this.orderId, productId: this.productId, quantity: this.quantity}
    }

    get orderId(): number{
        return this._orderId;
    }

    get productId(): number{
        return this._productId;
    }

    get quantity(): number{
        return this._quantity;
    }
    get product(): Product{
        return this._product;
    }
    setProduct(product: Product){
        this._product = product;
    }
    
}