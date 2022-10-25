import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import {SingleClientI} from '../../models/clients/singleClient.interface'
import {ClientRequestI} from '../../models/clients/clientRequest.interface'
import {ResponseI} from '../../models/response.interface'
import {ClientsService} from '../../service/clients/clients.service'

@Component({
  selector: 'app-view-client',
  templateUrl: './view-client.component.html',
  styleUrls: ['./view-client.component.css']
})
export class ViewClientComponent implements OnInit {

  constructor(private activerouter:ActivatedRoute, private router:Router,
    private api:ClientsService) { }

  clientInfoResponse:ResponseI;
  clientInfo:SingleClientI = {
    "nombreCompleto":"",
    "telefonos":[0,0],
    "cedula":"",
    "correo":"",
    "direccion":"",
    "usuario":"",
    "password":"",
    "puntos":0
}
  clientRequest:ClientRequestI;

  ngOnInit(): void {

    let clientId = this.activerouter.snapshot.paramMap.get('id');
    this.clientRequest = {'cedula':clientId}

    this.api.getSingleClient(this.clientRequest).subscribe(data =>{
      this.clientInfoResponse = data;
      if(this.clientInfoResponse.status == "ok"){
        this.clientInfo = this.clientInfoResponse.result;
      }else{
        alert("No se pudo cargar el Cliente")
      }
    })
  }

  edit(){
    this.router.navigate(["editClient", this.activerouter.snapshot.paramMap.get('id')])
  }

  delete(){
    this.api.deleteClient(this.clientRequest)
    this.router.navigate(["clients"])
  }

  exit(){
    this.router.navigate(["clients"])
  }
}
