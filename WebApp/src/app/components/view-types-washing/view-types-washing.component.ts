import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import {SingleTypeWashingI} from '../../models/types-washing/singleTypeWashing.interface'
import {TypesWashingRequestI} from '../../models/types-washing/typeWashingRequest.interface'
import {ResponseI} from '../../models/response.interface'
import {TypesWashingService} from '../../service/types-washing/types-washing.service'

@Component({
  selector: 'app-view-types-washing',
  templateUrl: './view-types-washing.component.html',
  styleUrls: ['./view-types-washing.component.css']
})
export class ViewTypesWashingComponent implements OnInit {

  constructor(private activerouter:ActivatedRoute, private router:Router,
    private api:TypesWashingService) { }

  typeWashingInfoResponse:ResponseI;
  typeWashingInfo:SingleTypeWashingI = {
    "id_Lavado":"",
    "personalRequerido":0,
    "precio":0,
    "costo":0,
    "nombre":"",
    "duracion":0,
    "puntuacionLealtad":0,
    "productosUtilizados":[]
  }
  typeWashingRequest:TypesWashingRequestI;

  ngOnInit(): void {

    let typeWashingId = this.activerouter.snapshot.paramMap.get('id');
    this.typeWashingRequest = {"id_Lavado":typeWashingId}
    
    this.api.getSingleTypeWashing(this.typeWashingRequest).subscribe(data =>{
      this.typeWashingInfoResponse = data;
      if(this.typeWashingInfoResponse.status == "ok"){
        this.typeWashingInfo = this.typeWashingInfoResponse.result;
      }else{
        alert("No se pudo cargar el tipo de lavado")
      }
    })
  }
  
  edit(){
    this.router.navigate(["editTypeWashing", this.activerouter.snapshot.paramMap.get('id')])
  }

  delete(){
    this.api.deleteTypeWashing(this.typeWashingRequest).subscribe();
    this.exit()
  }

  exit(){
    this.router.navigate(["typesWashing"])
  }

}
