import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Observable} from 'rxjs'

import {LoginI} from '../../models/login/login.interface'
import {ResponseI} from '../../models/response.interface'


@Injectable({
  providedIn: 'root'
})
export class LoginService {

  url = 'http://localhost:7038/api/'
  constructor(private http:HttpClient) { }

  loginByEmail(form:LoginI): Observable<ResponseI>{
    let direccion = this.url + "auth"
    return this.http.post<ResponseI>(direccion,form)
  }
}
