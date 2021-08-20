export interface ProductJson{
  productId: number;
  //productId: number
  productClass: string;
  productName: string;
  unitPrice: number;
  availability: number;
  description: string;
  inStock: boolean;
  
}


export class Product {
  private _productId: number;
    //private _productId: number;
    constructor(        
      private _productClass: string,
      private _productName: string,
      private _unitPrice: number, //ts equivalent of doubles and ints
      private _availability: number,
      private _description: string,  
      private _inStock: boolean,     

    ) {
        this.calculateInStock();

    }

    static fromJSON(json: ProductJson): Product {
      console.log("printing fromjson");
      console.log(json);
      const prod = new Product(json.productClass, json.productName, json.unitPrice, json.availability, json.description, json.inStock);
      //private _productId: number;
      prod._productId = json.productId;
    /* console.log("printing fromjson");
      console.log(prod);*/
      return prod;
    }
   
    /*setProductName(productName: string)
    {
      this._productName = productName;
    }
    setProductClass(productClass: string)
    {
      this._productClass = productClass;
    }
    setUnitPrice(unitPrice: number)
    {
      this._unitPrice = unitPrice;
    }
    setAvailability(availability: number)
    {
      this._availability = availability;
    }
    setDescription(description: string)
    {
      this._description = description;
    }
    
    setProductId(productId : number)
    {
      this._productId = productId;
    }*/
    setProductId(productId : number)
    {
      this._productId = productId;
    }
    setInStock(instock: boolean){
      this._inStock = instock;
    }

    calculateInStock(){
        if(this.availability<=0){
          this.setInStock(false);
        }
        else{
          this.setInStock(true);
        }
    }
    toJSON(): ProductJson {
     // console.log("printing toJson");
      return <ProductJson>{  
        productId: this.productId,     
        productClass: this.productClass,
        productName: this.productName,
        unitPrice: this.unitPrice,
        availability: this.availability,
        description: this.description,        
        inStock: this.inStock,
      };
    }

  
    // [...] other getters


    get productClass(): string {
      return this._productClass;
    }

    get productId(): number {
      return this._productId;
    }

    get productName(): string{
      return this._productName;
    }

    get unitPrice(): number{
      return this._unitPrice;
    }
    
    get availability(): number{
      return this._availability;
    }

    get description(): string{
      return this._description;
    }
    
    get inStock(): boolean{
      return this._inStock;
    }
   
    
  }