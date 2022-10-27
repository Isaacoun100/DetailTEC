import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router'
import {ResponseI} from '../../models/response.interface'
import {AppointmentsI} from '../../models/appointments/appointments.interface'
import {AppointmentsService} from '../../service/appointments/appointments.service'

@Component({
  selector: 'app-appointments',
  templateUrl: './appointments.component.html',
  styleUrls: ['./appointments.component.css']
})
export class AppointmentsComponent implements OnInit {

  appointmentsResponse:ResponseI;
  appointments:AppointmentsI[];
  error_msg="";

  constructor(private router:Router,private api: AppointmentsService) { }

  ngOnInit(): void {
    
      this.api.getAppointments().subscribe(data =>{
        this.appointmentsResponse = data;
        if(this.appointmentsResponse.status=="ok"){
          this.appointments = this.appointmentsResponse.result;
        }else{
          this.error_msg= "No se pudieron cargar las citas"
        }
      })
    
  }

  viewAppointment(id:string){
    this.router.navigate(["viewAppointment", id])
  }

  newAppointment(){
    this.router.navigate(["newAppointment"])
  }

}
