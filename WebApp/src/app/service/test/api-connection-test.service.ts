import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {InformationTestI} from '../../interfaces/information-test.interface'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiConnectionTestService {

  url = 'http://localhost:7038/api/'

  constructor(private http:HttpClient) { }

  getInformationTest():Observable<InformationTestI[]>{
    let direccion = this.url + "test-information";
    return this.http.get<InformationTestI[]>(direccion);
  }
}
