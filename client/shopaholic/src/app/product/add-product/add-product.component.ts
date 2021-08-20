import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ProductDataService } from '../product-data.service';

import { Product } from '../product.model';


function validateProductClassAndName(control: FormGroup)
: { [key: string]: any }{
  if(
    control.get('productClass').value.length >=3 && control.get('productName').value.length <3
  ){
    return {productClassNoName: true}
  }
  else if(
    control.get('productName').value.length >=3 && control.get('productClass').value.length <3  
  )
  {
    return {productNameNoClass: true}
  }
  return null
}

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
  })

export class AddProductComponent implements OnInit {
 @Output() public newProduct = new EventEmitter<Product>();
  public product: FormGroup;
  public errorMessage : string = '';
  constructor(private fb: FormBuilder,
    private _productDataService: ProductDataService  ,
   private _router: Router
    ) { }

  ngOnInit() {
  this.product = this.fb.group({
    
  productClass: this.fb.control('Laptop'
 /*  , [Validators.required, Validators.minLength(3)],
  //async validator
  []  */ 
  ),
  productName: this.fb.control('Rog strix'
  // , [Validators.required, Validators.minLength(3)]
  ),
  unitPrice: this.fb.control(300, 
    //Validators.required
    ),
  availability: this.fb.control(0),
  description: this.fb.control('Good laptop'),  
  inStock: this.fb.control(false)

  },
  {validator: validateProductClassAndName}
  )
  }
  onSubmit()
  {
    //this.newProduct.emit(new Product(this.product.value.productClass, this.product.value.productName, this.product.value.unitPrice, this.product.value.availability, this.product.value.description,this.product.value.userId));
    this._productDataService.addNewProduct(
      new Product(this.product.value.productClass, this.product.value.productName, this.product.value.unitPrice, this.product.value.availability, this.product.value.description,this.product.value.inStock)
    );

    this._router.navigate(['/product/list']);
    console.log("line before reloading");
    this.reloadTargetRoute();
  }
   //reload component
   reloadTargetRoute() {
    let targetUrl = '/product/list'//this._router.url;
    this._router.navigateByUrl('/', {skipLocationChange: false}).then(() => {
        this._router.navigate([targetUrl]);
        console.log(targetUrl);
    });
  
}


  //the addproduct event is called when the button in the html of add product is clicked
  /*addProduct(productClass:HTMLInputElement,productName: HTMLInputElement, unitPrice: HTMLInputElement, availability:
  HTMLInputElement, description: HTMLInputElement,userId: HTMLInputElement): boolean{
  console.log(productClass.value);
  console.log(productName.value);
  console.log(unitPrice.value);
  console.log(availability.value);
  console.log(description.value);

  console.log(userId.value);
  /*const product = new Product(productClass.value, productName.value, unitPrice.valueAsNumber,
  availability.valueAsNumber, description.value, userId.valueAsNumber);
  this.newProduct.emit(product);*/
  /*return false;
  }*/

  getErrorMessage(errors: any): string {
    //an error occured on the required state
    if(errors.required)
    {
      return 'is required';
    }
    //min length error occured
    else if (errors.minLength)
    {
      return `needs at least ${errors.minlength.requiredLength}
      characters (got ${errors.minlength.actualLength})`;
    }
    else if(errors.productClassNoName)
    {
      return `if productclass is set you need to set the productname`
    }
    else if(errors.productNameNoClass)
    {
      return `if productname is set you need to set the productclass`
    }
  }
  /*showProductList(){
    this._router.navigate(['/product/list']);
  }*/

  }
