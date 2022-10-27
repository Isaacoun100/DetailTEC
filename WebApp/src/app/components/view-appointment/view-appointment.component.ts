import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import {SingleAppointmentI} from '../../models/appointments/singleAppointment.interface'
import {AppointmentsRequestI} from '../../models/appointments/appointmentRequest.interface'
import {ResponseI} from '../../models/response.interface'
import {AppointmentsService} from '../../service/appointments/appointments.service'

@Component({
  selector: 'app-view-appointment',
  templateUrl: './view-appointment.component.html',
  styleUrls: ['./view-appointment.component.css']
})
export class ViewAppointmentComponent implements OnInit {

  constructor(private activerouter:ActivatedRoute, private router:Router,
    private api:AppointmentsService) { }

  appointmentInfoResponse:ResponseI;
  appointmentInfo:SingleAppointmentI = {
    "cliente":0,
    "placaVehiculo":"",
    "sucursal":"",
    "tipoLavado":"",
    "responsable":0,
    "factura":"",
    "numeroCita":""
} 
  appointmentRequest:AppointmentsRequestI;

  ngOnInit(): void {

    let appointmentId = this.activerouter.snapshot.paramMap.get('id');
    this.appointmentRequest = {"numeroCita":appointmentId}
    
    this.api.getSingleAppointment(this.appointmentRequest).subscribe(data =>{
      this.appointmentInfoResponse = data;
      if(this.appointmentInfoResponse.status == "ok"){
        this.appointmentInfo = this.appointmentInfoResponse.result;
      }else{
        alert("No se pudo cargar la cita")
      }
    })
    
  }
  
  edit(){
    this.router.navigate(["editAppointment", this.activerouter.snapshot.paramMap.get('id')])
  }

  delete(){
    this.api.deleteAppointment(this.appointmentRequest)
    this.exit()
  }

  exit(){
    this.router.navigate(["appointments"])
  }

}
