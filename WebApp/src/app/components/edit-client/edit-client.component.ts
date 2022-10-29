import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import {SingleClientI} from '../../models/clients/singleClient.interface'
import {ClientRequestI} from '../../models/clients/clientRequest.interface'
import {ResponseI} from '../../models/response.interface'
import {ClientsService} from '../../service/clients/clients.service'
import {FormGroup, FormControl, Validators} from '@angular/forms'

@Component({
  selector: 'app-edit-client',
  templateUrl: './edit-client.component.html',
  styleUrls: ['./edit-client.component.css']
})
export class EditClientComponent implements OnInit {

  constructor(private activerouter:ActivatedRoute, private router:Router,
    private api:ClientsService) { }

  clientInfoResponse:ResponseI;
  clientInfo:SingleClientI;
  clientRequest:ClientRequestI;
  realForm:SingleClientI={
    "nombreCompleto":"",
    "telefonos":[0,0],
    "cedula":"",
    "correo":"",
    "direccion":"",
    "usuario":"",
    "contrasena":"",
    "puntos":456
  }
  

  editForm = new FormGroup({
    nombreCompleto: new FormControl(''),
    telefono1: new FormControl(''),
    telefono2: new FormControl(''),
    cedula: new FormControl(''),
    correo: new FormControl(''),
    direccion: new FormControl(''),
    usuario: new FormControl(''),
    contrasena: new FormControl(''),
    puntos:new FormControl(''),
}) 

  ngOnInit(): void {

    let cliendId = this.activerouter.snapshot.paramMap.get('id');
    this.clientRequest = {'cedula': cliendId} 
    
    this.api.getSingleClient(this.clientRequest).subscribe(data =>{
      this.clientInfoResponse = data;
      if(this.clientInfoResponse.status == "ok"){
        this.clientInfo = data.result;
        this.editForm.setValue({
          'nombreCompleto' : this.clientInfo.nombreCompleto,
          'telefono1': this.clientInfo.telefonos[0],
          'telefono2': this.clientInfo.telefonos[1],
          'cedula': this.clientInfo.cedula,
          'correo': this.clientInfo.correo,
          'direccion': this.clientInfo.direccion,
          'usuario':this.clientInfo.usuario,
          'contrasena': this.clientInfo.contrasena,
          'puntos':this.clientInfo.puntos
        })
      }else{
        alert("No se pudo cargar el cliente")
      }})
      
  }

  putForm(form:any){
    this.realForm.nombreCompleto = form.nombreCompleto
    this.realForm.cedula = form.cedula
    this.realForm.telefonos[0] = form.telefono1
    this.realForm.telefonos[1] = form.telefono2
    this.realForm.correo = form.correo
    this.realForm.direccion = form.direccion
    this.realForm.usuario = form.usuario
    this.realForm.contrasena = form.contrasena
    this.realForm.puntos = form.puntos

    this.api.putClient(this.realForm).subscribe();
    this.exit()

  }

  exit(){
    this.router.navigate(["viewClient", this.activerouter.snapshot.paramMap.get('id')])
  }
}
