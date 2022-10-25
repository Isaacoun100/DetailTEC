import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router'
import {ResponseI} from '../../models/response.interface'
import {ClientsI} from '../../models/clients/clients.interface'
import {ClientsService} from '../../service/clients/clients.service'

@Component({
  selector: 'app-clients',
  templateUrl: './clients.component.html',
  styleUrls: ['./clients.component.css']
})
export class ClientsComponent implements OnInit {

  clientsResponse:ResponseI;
  clients:ClientsI[];
  error_msg="";

  constructor(private router:Router,private api: ClientsService) { }

  ngOnInit(): void {
    this.api.getClients().subscribe(data =>{
      this.clientsResponse = data;
      if(this.clientsResponse.status=="ok"){
        this.clients = this.clientsResponse.result;
      }else{
        this.error_msg= "No se pudieron cargar los clientes"
      }
    })
  }

  viewClient(id:string){
    this.router.navigate(["viewClient", id])
  }

  newClient(){
    this.router.navigate(["newClient"])
  }
}
