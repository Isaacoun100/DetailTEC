import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import {SingleAppointmentI} from '../../models/appointments/singleAppointment.interface'
import {AppointmentsRequestI} from '../../models/appointments/appointmentRequest.interface'
import {ResponseI} from '../../models/response.interface'
import {AppointmentsService} from '../../service/appointments/appointments.service'
import {FormGroup, FormControl} from '@angular/forms'

@Component({
  selector: 'app-edit-appointment',
  templateUrl: './edit-appointment.component.html',
  styleUrls: ['./edit-appointment.component.css']
})
export class EditAppointmentComponent implements OnInit {

  constructor(private activerouter:ActivatedRoute, private router:Router,
    private api:AppointmentsService) { }

  appointmentInfoResponse:ResponseI;
  appointmentRequest:AppointmentsRequestI;
  appointmentInfo:SingleAppointmentI;
  
  editForm = new FormGroup({
    cliente: new FormControl(''),
    placaVehiculo: new FormControl(''),
    sucursal: new FormControl(''),
    tipoLavado: new FormControl(''),
    responsable: new FormControl(''),
    factura: new FormControl(''),
    numeroCita: new FormControl('')
}) 


  ngOnInit(): void {

    let appointmentId = this.activerouter.snapshot.paramMap.get('id');
    this.appointmentRequest = {'numeroCita':appointmentId}

    this.api.getSingleAppointment(this.appointmentRequest).subscribe(data =>{
      this.appointmentInfoResponse = data;
      if(this.appointmentInfoResponse.status == "ok"){
        this.appointmentInfo = data.result;
        this.editForm.setValue({
          'cliente' : this.appointmentInfo.cliente,
          'placaVehiculo': this.appointmentInfo.placaVehiculo,
          'sucursal': this.appointmentInfo.sucursal,
          'tipoLavado': this.appointmentInfo.tipoLavado,
          'responsable': this.appointmentInfo.responsable,
          'factura':this.appointmentInfo.factura,
          'numeroCita': this.appointmentInfo.numeroCita
        })
      }else{
        alert("No se pudo cargar la cita")
      }})
      
  }

  putForm(form:SingleAppointmentI){
    this.api.putAppointment(form);
    this.exit();
  }

  exit(){
    this.router.navigate(["viewAppointment", this.activerouter.snapshot.paramMap.get('id')])
  }

}
