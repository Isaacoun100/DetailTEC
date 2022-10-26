import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import {ResponseI} from '../../models/response.interface'
import {SingleProviderI} from '../../models/providers/singleProvider.interface'
import {ProviderRequestI} from '../../models/providers/providerRequest.interface'
import * as myGlobals from '../../../../src/globals'

@Injectable({
  providedIn: 'root'
})
export class ProvidersService {

  url = myGlobals.URL

  constructor(private http:HttpClient) { }

  getProviders():Observable<ResponseI>{
    let direccion = this.url + "getAllProviders";
    return this.http.get<ResponseI>(direccion);
  }

  getSingleProvider(id:ProviderRequestI):Observable<ResponseI>{
    let direccion = this.url + "getProvider"
    return this.http.post<ResponseI>(direccion,id);
  }

  putProvider(form:SingleProviderI){
    let direccion = this.url + "updateProvider";
    return this.http.put(direccion,form);
  }

  deleteProvider(id:ProviderRequestI){
    let direccion = this.url + "deleteProvider";
    let Options = {
      headers: new HttpHeaders({
        'Conten-type':'application/json'
      }),
      body:id
    }
    return this.http.delete(direccion,Options);
  }

  postProvider(form:SingleProviderI){
    let direccion = this.url + "addProvider";
    return this.http.post(direccion,form)
  }
  //TEST
  getTest():Observable<ResponseI>{
    let direccion = this.url + "UserControllerTest";
    return this.http.get<ResponseI>(direccion);
  }
}
