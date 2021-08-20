import {
  Order
} from "../order/order.model";

interface UserJson {
  /*
  firstName
  lastName
  email
  orders
  */
  firstName: string;
  lastName: string;
  email: string;
  orders: Order[];

}
export class User {

  constructor(
    private _firstName: string,
    private _lastName: string,
    private _email: string,
    private _orders = new Array < Order > (),
  ) {}

  static fromJson(json: UserJson): User {
    const user = new User(
      json.firstName, json.lastName, json.email,
      json.orders);
    return user;


  }

  toJSON(): UserJson {
    return <UserJson > {
      firstName: this._firstName,
      lastName: this._lastName,
      email: this._email,
      orders: this._orders
    }
  }

  get firstName(): string{
      return this._firstName;
  }

  get lastName(): string{
      return this._lastName;
  }
  get email(): string{
      return this._email;
  }
  get orders(): Array<Order>{
      return this._orders;
  }
}
