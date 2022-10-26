import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import {ResponseI} from '../../models/response.interface'
import {SingleTypeWashingI} from '../../models/types-washing/singleTypeWashing.interface'
import {TypesWashingRequestI} from '../../models/types-washing/typeWashingRequest.interface'
import * as myGlobals from '../../../../src/globals'

@Injectable({
  providedIn: 'root'
})
export class TypesWashingService {

  url = myGlobals.URL

  constructor(private http:HttpClient) { }

  getTypesWashing():Observable<ResponseI>{
    let direccion = this.url + "getAllCarWash";
    return this.http.get<ResponseI>(direccion);
  }

  getSingleTypeWashing(id:TypesWashingRequestI):Observable<ResponseI>{
    let direccion = this.url + "getCarWashType"
    return this.http.post<ResponseI>(direccion,id);
  }

  putTypeWashing(form:SingleTypeWashingI){
    let direccion = this.url + "updateCarWashType";
    return this.http.put(direccion,form);
  }

  deleteTypeWashing(id:TypesWashingRequestI){
    let direccion = this.url + "deleteCarWashType";
    let Options = {
      headers: new HttpHeaders({
        'Conten-type':'application/json'
      }),
      body:id
    }
    return this.http.delete(direccion,Options);
  }

  postTypeWashing(form:SingleTypeWashingI){
    let direccion = this.url + "addCarWashType";
    return this.http.post(direccion,form)
  }
  //TEST
  getTest():Observable<ResponseI>{
    let direccion = this.url + "UserControllerTest";
    return this.http.get<ResponseI>(direccion);
  }
}