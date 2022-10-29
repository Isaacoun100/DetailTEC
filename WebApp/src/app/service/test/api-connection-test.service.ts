import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {InformationTestI} from '../../interfaces/information-test.interface'
import * as myGlobals from '../../../../src/globals'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiConnectionTestService {

  url = myGlobals.URL
  constructor(private http:HttpClient) { }

  getInformationTest():Observable<InformationTestI[]>{
    let direccion = this.url + "UserControllerTest";
    return this.http.get<InformationTestI[]>(direccion);
  }
}
