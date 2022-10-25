import { Component, OnInit } from '@angular/core';
import {FormGroup, FormControl, Validators} from '@angular/forms'
import {SingleClientI} from '../../models/clients/singleClient.interface'
import {ClientsService} from '../../service/clients/clients.service'
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-new-client',
  templateUrl: './new-client.component.html',
  styleUrls: ['./new-client.component.css']
})
export class NewClientComponent implements OnInit {

  constructor(private activerouter:ActivatedRoute, private router:Router,
    private api:ClientsService) { }

    realForm:SingleClientI={
      "nombreCompleto":"",
      "telefonos":[0,0],
      "cedula":"",
      "correo":"",
      "direccion":"",
      "usuario":"",
      "password":"",
      "puntos":456
    }

    newForm = new FormGroup({
      nombreCompleto: new FormControl(''),
      telefono1: new FormControl(''),
      telefono2: new FormControl(''),
      cedula: new FormControl(''),
      correo: new FormControl(''),
      direccion: new FormControl(''),
      usuario: new FormControl(''),
      password: new FormControl(''),
      puntos:new FormControl(''),
  }) 

  ngOnInit(): void {
  }

  postForm(form:any){
    this.realForm.nombreCompleto = form.nombreCompleto
    this.realForm.cedula = form.cedula
    this.realForm.telefonos[0] = form.telefono1
    this.realForm.telefonos[1] = form.telefono2
    this.realForm.correo = form.correo
    this.realForm.direccion = form.direccion
    this.realForm.usuario = form.usuario
    this.realForm.password = form.password
    this.realForm.puntos = form.puntos
    this.api.postClient(this.realForm);
    this.newForm.reset();
  }

  exit(){
    this.router.navigate(["clients"])
  }
}
