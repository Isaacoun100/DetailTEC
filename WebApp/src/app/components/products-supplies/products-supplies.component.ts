import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router'
import {ResponseI} from '../../models/response.interface'
import {ProductsSuppliesI} from '../../models/products-supplies/productsSupplies.interface'
import {ProductsSuppliesService} from '../../service/products-supplies/products-supplies.service'

@Component({
  selector: 'app-products-supplies',
  templateUrl: './products-supplies.component.html',
  styleUrls: ['./products-supplies.component.css']
})
export class ProductsSuppliesComponent implements OnInit {

  productsResponse:ResponseI;
  products:ProductsSuppliesI[];
  error_msg="";

  constructor(private router:Router,private api: ProductsSuppliesService) { }

  ngOnInit(): void {
    
      this.api.getProducts().subscribe(data =>{
        this.productsResponse = data;
        if(this.productsResponse.status=="ok"){
          this.products = this.productsResponse.result;
        }else{
          this.error_msg= "No se pudieron cargar los productos y suministros"
        }
      })
    
  }

  viewProduct(id:string){
    this.router.navigate(["viewProduct", id])
  }

  newProduct(){
    this.router.navigate(["newProduct"])
  }

}
