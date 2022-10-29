import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import {ResponseI} from '../../models/response.interface'
import {SingleAppointmentI} from '../../models/appointments/singleAppointment.interface'
import {AppointmentsRequestI} from '../../models/appointments/appointmentRequest.interface'
import * as myGlobals from '../../../../src/globals'

@Injectable({
  providedIn: 'root'
})
export class AppointmentsService {

  url = myGlobals.URL

  constructor(private http:HttpClient) { }

  getAppointments():Observable<ResponseI>{
    let direccion = this.url + "getAllAppointments";
    return this.http.get<ResponseI>(direccion);
  }

  getSingleAppointment(id:AppointmentsRequestI):Observable<ResponseI>{
    let direccion = this.url + "getAppointment"
    return this.http.post<ResponseI>(direccion,id);
  }

  putAppointment(form:SingleAppointmentI){
    let direccion = this.url + "updateAppointment";
    return this.http.put(direccion,form);
  }

  deleteAppointment(id:AppointmentsRequestI){
    let direccion = this.url + "deleteAppointment";
    let Options = {
      headers: new HttpHeaders({
        'Conten-type':'application/json'
      }),
      body:id
    }
    return this.http.delete(direccion,Options);
  }

  postAppointment(form:SingleAppointmentI){
    let direccion = this.url + "addAppointment";
    return this.http.post(direccion,form)
  }
  //TEST
  getTest():Observable<ResponseI>{
    let direccion = this.url + "UserControllerTest";
    return this.http.get<ResponseI>(direccion);
  }
}
