import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import {ResponseI} from '../../models/response.interface'
import {SingleProductSupplyI} from '../../models/products-supplies/singleProductSupply.interface'
import {ProductSupplyRequestI} from '../../models/products-supplies/productSupplyRequest.interface'
import * as myGlobals from '../../../../src/globals'

@Injectable({
  providedIn: 'root'
})
export class ProductsSuppliesService {

  url = myGlobals.URL

  constructor(private http:HttpClient) { }

  getProducts():Observable<ResponseI>{
    let direccion = this.url + "getAllProducts";
    return this.http.get<ResponseI>(direccion);
  }

  getSingleProduct(id:ProductSupplyRequestI):Observable<ResponseI>{
    let direccion = this.url + "getProduct"
    return this.http.post<ResponseI>(direccion,id);
  }

  putProduct(form:SingleProductSupplyI){
    let direccion = this.url + "updateProduct";
    return this.http.put(direccion,form);
  }

  deleteProduct(id:ProductSupplyRequestI){
    let direccion = this.url + "deleteProduct";
    let Options = {
      headers: new HttpHeaders({
        'Conten-type':'application/json'
      }),
      body:id
    }
    return this.http.delete(direccion,Options);
  }

  postProduct(form:SingleProductSupplyI){
    let direccion = this.url + "addProduct";
    return this.http.post(direccion,form)
  }
  //TEST
  getTest():Observable<ResponseI>{
    let direccion = this.url + "UserControllerTest";
    return this.http.get<ResponseI>(direccion);
  }
}
