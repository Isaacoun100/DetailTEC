import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import {SingleProductSupplyI} from '../../models/products-supplies/singleProductSupply.interface'
import {ProductSupplyRequestI} from '../../models/products-supplies/productSupplyRequest.interface'
import {ResponseI} from '../../models/response.interface'
import {ProductsSuppliesService} from '../../service/products-supplies/products-supplies.service'

@Component({
  selector: 'app-view-product',
  templateUrl: './view-product.component.html',
  styleUrls: ['./view-product.component.css']
})
export class ViewProductComponent implements OnInit {

  constructor(private activerouter:ActivatedRoute, private router:Router,
    private api:ProductsSuppliesService) { }

  productInfoResponse:ResponseI;
  productInfo:SingleProductSupplyI = {
    "nombre":"",
    "marca":"",
    "costo":0,
    "proveedores":[]
}
  productRequest:ProductSupplyRequestI;

  ngOnInit(): void {

    let productId = this.activerouter.snapshot.paramMap.get('id');
    this.productRequest = {"nombre":productId}
    this.api.getSingleProduct(this.productRequest).subscribe(data =>{
      this.productInfoResponse = data;
      console.log(data);
      if(this.productInfoResponse.status == "ok"){
        this.productInfo = this.productInfoResponse.result;
      }else{
        alert("No se pudo cargar el producto")
      }
    })
  }
  
  edit(){
    this.router.navigate(["editProduct", this.activerouter.snapshot.paramMap.get('id')])
  }

  delete(){
    this.api.deleteProduct(this.productRequest).subscribe();
    this.exit()
  }

  exit(){
    this.router.navigate(["products"])
  }

}
