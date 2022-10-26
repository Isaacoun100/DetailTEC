import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import {SingleProviderI} from '../../models/providers/singleProvider.interface'
import {ProviderRequestI} from '../../models/providers/providerRequest.interface'
import {ResponseI} from '../../models/response.interface'
import {ProvidersService} from '../../service/providers/providers.service'
import {FormGroup, FormControl} from '@angular/forms'

@Component({
  selector: 'app-edit-provider',
  templateUrl: './edit-provider.component.html',
  styleUrls: ['./edit-provider.component.css']
})
export class EditProviderComponent implements OnInit {

  constructor(private activerouter:ActivatedRoute, private router:Router,
    private api:ProvidersService) { }

  providerInfoResponse:ResponseI;
  providerRequest:ProviderRequestI;
  providerInfo:SingleProviderI;
  
  editForm = new FormGroup({
    nombre: new FormControl(''),
    cedulaJuridica: new FormControl(''),
    direccion: new FormControl(''),
    correo: new FormControl(''),
    contacto: new FormControl('')
}) 


  ngOnInit(): void {

    let providerId = this.activerouter.snapshot.paramMap.get('id');
    this.providerRequest = {'cedulaJuridica':providerId}

    this.api.getSingleProvider(this.providerRequest).subscribe(data =>{
      this.providerInfoResponse = data;
      if(this.providerInfoResponse.status == "ok"){
        this.providerInfo = data.result;
        this.editForm.setValue({
          'nombre' : this.providerInfo.nombre,
          'cedulaJuridica': this.providerInfo.cedulaJuridica,
          'direccion': this.providerInfo.direccion,
          'correo': this.providerInfo.correo,
          'contacto': this.providerInfo.contacto
        })
      }else{
        alert("No se pudo cargar el proveedor")
      }})
      
      
  }

  putForm(form:SingleProviderI){
    this.api.putProvider(form);
    this.exit();
  }

  exit(){
    this.router.navigate(["viewProvider", this.activerouter.snapshot.paramMap.get('id')])
  }
}
