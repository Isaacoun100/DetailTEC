import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import {ResponseI} from '../../models/response.interface'
import {SingleBranchI} from '../../models/branches/singleBranch.interface'
import {BranchRequestI} from '../../models/branches/branchRequest.interface'
import * as myGlobals from '../../../../src/globals'

@Injectable({
  providedIn: 'root'
})
export class BranchesService {

  url = myGlobals.URL

  constructor(private http:HttpClient) { }

  getBranches():Observable<ResponseI>{
    let direccion = this.url + "getAllBranches";
    return this.http.get<ResponseI>(direccion);
  }

  getSingleBranch(id:BranchRequestI):Observable<ResponseI>{
    let direccion = this.url + "getBranch"
    return this.http.post<ResponseI>(direccion,id);
  }

  putBranch(form:SingleBranchI){
    let direccion = this.url + "updateBranch";
    return this.http.put(direccion,form);
  }

  deleteBranch(id:BranchRequestI){
    let direccion = this.url + "deleteBranch";
    let Options = {
      headers: new HttpHeaders({
        'Conten-type':'application/json'
      }),
      body:id
    }
    return this.http.delete(direccion,Options);
  }

  poatBranch(form:SingleBranchI){
    let direccion = this.url + "addBranch";
    return this.http.post(direccion,form)
  }
}
