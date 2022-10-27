import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import {SingleAppointmentI} from '../../models/appointments/singleAppointment.interface'
import {AppointmentsService} from '../../service/appointments/appointments.service'
import {FormGroup, FormControl} from '@angular/forms'

@Component({
  selector: 'app-new-appointment',
  templateUrl: './new-appointment.component.html',
  styleUrls: ['./new-appointment.component.css']
})
export class NewAppointmentComponent implements OnInit {

  constructor(private activerouter:ActivatedRoute, private router:Router,
    private api:AppointmentsService) { }

  appointmentInfo:SingleAppointmentI;
  
  newForm = new FormGroup({
    cliente: new FormControl(''),
    placaVehiculo: new FormControl(''),
    sucursal: new FormControl(''),
    tipoLavado: new FormControl(''),
    responsable: new FormControl(''),
    factura: new FormControl(''),
    numeroCita: new FormControl('')
}) 


  ngOnInit(): void {
      
  }

  postForm(form:SingleAppointmentI){
    this.api.postAppointment(form);
    this.newForm.reset()
  }

  exit(){
    this.router.navigate(["appointments"])
  }

}
