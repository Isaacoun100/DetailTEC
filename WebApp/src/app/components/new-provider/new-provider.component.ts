import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import {SingleProviderI} from '../../models/providers/singleProvider.interface'
import {ProviderRequestI} from '../../models/providers/providerRequest.interface'
import {ResponseI} from '../../models/response.interface'
import {ProvidersService} from '../../service/providers/providers.service'
import {FormGroup, FormControl} from '@angular/forms'

@Component({
  selector: 'app-new-provider',
  templateUrl: './new-provider.component.html',
  styleUrls: ['./new-provider.component.css']
})
export class NewProviderComponent implements OnInit {

  constructor(private activerouter:ActivatedRoute, private router:Router,
    private api:ProvidersService) { }

  providerInfoResponse:ResponseI;
  providerRequest:ProviderRequestI;
  providerInfo:SingleProviderI;
  
  newForm = new FormGroup({
    nombre: new FormControl(''),
    cedulaJuridica: new FormControl(''),
    direccion: new FormControl(''),
    correo: new FormControl(''),
    contacto: new FormControl('')
}) 


  ngOnInit(): void {  
  }

  postForm(form:SingleProviderI){
    this.api.postProvider(form).subscribe();
    this.newForm.reset()
  }

  exit(){
    this.router.navigate(["providers"])
  }

}
