import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import {SingleProductSupplyI} from '../../models/products-supplies/singleProductSupply.interface'
import {ProductSupplyRequestI} from '../../models/products-supplies/productSupplyRequest.interface'
import {ResponseI} from '../../models/response.interface'
import {ProductsSuppliesService} from '../../service/products-supplies/products-supplies.service'
import {FormGroup, FormControl} from '@angular/forms'

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent implements OnInit {

  constructor(private activerouter:ActivatedRoute, private router:Router,
    private api:ProductsSuppliesService) { 
      
    }
    
    productInfoResponse:ResponseI;
    productRequest:ProductSupplyRequestI;
    productInfo:SingleProductSupplyI;
  
  
    editForm = new FormGroup({
      nombre:new FormControl(''),
      marca: new FormControl(''),
      costo: new FormControl(''),
      proveedores: new FormControl([])
    }) 
  
    
    ngOnInit(): void {
  
      let productId = this.activerouter.snapshot.paramMap.get('id');
      this.productRequest = {'nombre':productId}
  
      this.api.getSingleProduct(this.productRequest).subscribe(data =>{
        this.productInfoResponse = data;
        if(this.productInfoResponse.status == "ok"){
          this.productInfo = data.result;
          this.editForm.setValue({
            'nombre' : this.productRequest.nombre,
            'marca': this.productInfo.marca,
            'costo': this.productInfo.costo,
            'proveedores': this.productInfo.proveedores
          })
        }else{
          alert("No se pudo cargar el producto")
        }})
    }
  
  
    putForm(form:SingleProductSupplyI){
      this.api.putProduct(form);
      this.exit();
    }
  
    exit(){
      this.router.navigate(["viewProduct", this.activerouter.snapshot.paramMap.get('id')])
    }

}
