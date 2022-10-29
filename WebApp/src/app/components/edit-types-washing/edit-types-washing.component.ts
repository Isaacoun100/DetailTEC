import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import {SingleTypeWashingI} from '../../models/types-washing/singleTypeWashing.interface'
import {TypesWashingRequestI} from '../../models/types-washing/typeWashingRequest.interface'
import {ResponseI} from '../../models/response.interface'
import {TypesWashingService} from '../../service/types-washing/types-washing.service'
import {FormGroup, FormControl} from '@angular/forms'

@Component({
  selector: 'app-edit-types-washing',
  templateUrl: './edit-types-washing.component.html',
  styleUrls: ['./edit-types-washing.component.css']
})
export class EditTypesWashingComponent implements OnInit {

  constructor(private activerouter:ActivatedRoute, private router:Router,
    private api:TypesWashingService) { 
      
    }
    
    typeWashingInfoResponse:ResponseI;
    typeWashingRequest:TypesWashingRequestI;
    typeWashingInfo:SingleTypeWashingI;
  
  
    editForm = new FormGroup({
      id_Lavado:new FormControl(''),
      personalRequerido: new FormControl(''),
      precio: new FormControl(''),
      costo: new FormControl(''),
      nombre: new FormControl(''),
      duracion: new FormControl(''),
      productosUtilizados: new FormControl([]),
      puntuacionLealtad: new FormControl('')
    }) 
  
    
    ngOnInit(): void {
  
      let typeWashingId = this.activerouter.snapshot.paramMap.get('id');
      this.typeWashingRequest = {'id_Lavado':typeWashingId}
  
      this.api.getSingleTypeWashing(this.typeWashingRequest).subscribe(data =>{
        this.typeWashingInfoResponse = data;
        if(this.typeWashingInfoResponse.status == "ok"){
          this.typeWashingInfo = data.result;
          this.editForm.setValue({
            'id_Lavado' : this.typeWashingRequest.id_Lavado,
            'personalRequerido': this.typeWashingInfo.personalRequerido,
            'precio': this.typeWashingInfo.precio,
            'costo': this.typeWashingInfo.costo,
            'nombre': this.typeWashingInfo.nombre,
            'duracion':this.typeWashingInfo.duracion,
            'productosUtilizados': this.typeWashingInfo.productosUtilizados,
            'puntuacionLealtad':this.typeWashingInfo.puntuacionLealtad
          })
        }else{
          alert("No se pudo cargar el tipo de lavado")
        }})
    }
  
  
    putForm(form:SingleTypeWashingI){
      this.api.putTypeWashing(form).subscribe();
      this.exit();
    }
  
    exit(){
      this.router.navigate(["viewTypeWashing", this.activerouter.snapshot.paramMap.get('id')])
    }

}
