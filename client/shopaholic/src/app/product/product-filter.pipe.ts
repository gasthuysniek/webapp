import { Pipe, PipeTransform } from '@angular/core';
import { Product } from './product.model';

@Pipe({
  name: 'productFilter'
})
export class ProductFilterPipe implements PipeTransform {

  transform(products: Product[], name:string): Product[] {
    if(!name ||name.length == 0)
    {
      //no filter is applied
      return products;
    }
    return products.filter(prod =>
      prod.productName.toLowerCase().startsWith(       
        name.toLowerCase()));
      
  }

}
