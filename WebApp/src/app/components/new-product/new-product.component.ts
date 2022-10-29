import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { SingleProductSupplyI } from '../../models/products-supplies/singleProductSupply.interface'
import { ProductsSuppliesService } from '../../service/products-supplies/products-supplies.service'
import { FormGroup, FormControl } from '@angular/forms'

@Component({
  selector: 'app-new-product',
  templateUrl: './new-product.component.html',
  styleUrls: ['./new-product.component.css']
})
export class NewProductComponent implements OnInit {

  constructor(private activerouter:ActivatedRoute, private router:Router,
    private api:ProductsSuppliesService) { 
      
    }
    
    newForm = new FormGroup({
      nombre:new FormControl(''),
      marca: new FormControl(''),
      costo: new FormControl(''),
      proveedores: new FormControl([]),
    }) 
  
    
    ngOnInit(): void {
    }
  
  
    postForm(form:SingleProductSupplyI){
      this.api.postProduct(form).subscribe();
      this.newForm.reset()
    }
  
    exit(){
      this.router.navigate(["products"])
    }

}
