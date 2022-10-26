import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router'
import {ResponseI} from '../../models/response.interface'
import {ProvidersI} from '../../models/providers/providers.interface'
import {ProvidersService} from '../../service/providers/providers.service'

@Component({
  selector: 'app-providers',
  templateUrl: './providers.component.html',
  styleUrls: ['./providers.component.css']
})
export class ProvidersComponent implements OnInit {

  providersResponse:ResponseI;
  providers:ProvidersI[];
  error_msg="";

  constructor(private router:Router,private api: ProvidersService) { }

  ngOnInit(): void {
    
      this.api.getProviders().subscribe(data =>{
        this.providersResponse = data;
        if(this.providersResponse.status=="ok"){
          this.providers = this.providersResponse.result;
        }else{
          this.error_msg= "No se pudieron cargar los proveedores"
        }
      })
  }

  viewProvider(id:string){
    this.router.navigate(["viewProvider", id])
  }

  newProvider(){
    this.router.navigate(["newProvider"])
  }

}
