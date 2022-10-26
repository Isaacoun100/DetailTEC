import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import {SingleProviderI} from '../../models/providers/singleProvider.interface'
import {ProviderRequestI} from '../../models/providers/providerRequest.interface'
import {ResponseI} from '../../models/response.interface'
import {ProvidersService} from '../../service/providers/providers.service'

@Component({
  selector: 'app-view-provider',
  templateUrl: './view-provider.component.html',
  styleUrls: ['./view-provider.component.css']
})
export class ViewProviderComponent implements OnInit {

  constructor(private activerouter:ActivatedRoute, private router:Router,
    private api:ProvidersService) { }

  providerInfoResponse:ResponseI;
  providerInfo:SingleProviderI = {
    "nombre":"",
    "cedulaJuridica":"",
    "direccion":"",
    "correo":"",
    "contacto":""
}
  providerRequest:ProviderRequestI;

  ngOnInit(): void {

    let providerId = this.activerouter.snapshot.paramMap.get('id');
    this.providerRequest = {"cedulaJuridica":providerId}
    
    this.api.getSingleProvider(this.providerRequest).subscribe(data =>{
      this.providerInfoResponse = data;
      if(this.providerInfoResponse.status == "ok"){
        this.providerInfo = this.providerInfoResponse.result;
      }else{
        alert("No se pudo cargar el proveedor")
      }
    })
    
  }
  
  edit(){
    this.router.navigate(["editProvider", this.activerouter.snapshot.paramMap.get('id')])
  }

  delete(){
    this.api.deleteProvider(this.providerRequest)
    this.exit()
  }

  exit(){
    this.router.navigate(["providers"])
  }

}
