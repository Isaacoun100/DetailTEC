import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {InformationTestI} from '../../interfaces/information-test.interface'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiConnectionTestService {

  url = 'http://localhost:7274/api/'
  constructor(private http:HttpClient) { }

  getInformationTest():Observable<InformationTestI[]>{
    let direccion = this.url + "UserControllerTest";
    return this.http.get<InformationTestI[]>(direccion);
  }
}
