import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import {ResponseI} from '../../models/response.interface'
import {SingleClientI} from '../../models/clients/singleClient.interface'
import {ClientRequestI} from '../../models/clients/clientRequest.interface'
import * as myGlobals from '../../../../src/globals'

@Injectable({
  providedIn: 'root'
})
export class ClientsService {

  url = myGlobals.URL

  constructor(private http:HttpClient) { }

  getClients():Observable<ResponseI>{
    let direccion = this.url + "getAllClients";
    return this.http.get<ResponseI>(direccion);
  }

  getSingleClient(id:ClientRequestI):Observable<ResponseI>{
    let direccion = this.url + "getClient"
    return this.http.post<ResponseI>(direccion,id);
  }

  putClient(form:SingleClientI){
    let direccion = this.url + "updateClient";
    return this.http.put(direccion,form);
  }

  deleteClient(id:ClientRequestI){
    let direccion = this.url + "deleteClient";
    let Options = {
      headers: new HttpHeaders({
        'Conten-type':'application/json'
      }),
      body:id
    }
    return this.http.delete(direccion,Options);
  }

  postClient(form:SingleClientI){
    let direccion = this.url + "addClient";
    return this.http.post(direccion,form)
  }

  //TEST
  getWorkerTest():Observable<ResponseI>{
    let direccion = this.url + "UserControllerTest";
    return this.http.get<ResponseI>(direccion);
  }
}
