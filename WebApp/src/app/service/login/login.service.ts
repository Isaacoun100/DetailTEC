import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Observable} from 'rxjs'

import {LoginI} from '../../models/login/login.interface'
import {ResponseI} from '../../models/response.interface'
import * as myGlobals from '../../../../src/globals'


@Injectable({
  providedIn: 'root'
})
export class LoginService {

  url = myGlobals.URL
  constructor(private http:HttpClient) { }

  loginByEmail(form:LoginI): Observable<ResponseI>{
    let direccion = this.url + "auth"
    return this.http.post<ResponseI>(direccion,form)
  }
}
