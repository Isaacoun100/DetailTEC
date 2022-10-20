import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import {ResponseI} from '../../models/response.interface'
import {SingleWorkerI} from '../../models/workers/singleWorker.interface'
import {WorkerRequestI} from '../../models/workers/workerRequest.interface'
import * as myGlobals from '../../../../src/globals'

@Injectable({
  providedIn: 'root'
})
export class WorkersService {

  url = myGlobals.URL

  constructor(private http:HttpClient) { }

  getWorkers():Observable<ResponseI>{
    let direccion = this.url + "getAllEmployees";
    return this.http.get<ResponseI>(direccion);
  }

  getSingleWorker(id:WorkerRequestI):Observable<ResponseI>{
    let direccion = this.url + "getEmployee"
    return this.http.post<ResponseI>(direccion,id);
  }

  putEmployee(form:SingleWorkerI){
    let direccion = this.url + "updateEmployee";
    return this.http.put(direccion,form);
  }

  deleteEmployee(id:WorkerRequestI){
    let direccion = this.url + "deleteEmployee";
    let Options = {
      headers: new HttpHeaders({
        'Conten-type':'application/json'
      }),
      body:id
    }
    return this.http.delete(direccion,Options);
  }

  postEmployee(form:SingleWorkerI){
    let direccion = this.url + "addEmployee";
    return this.http.post(direccion,form)
  }
}
