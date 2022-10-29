import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router'
import {ResponseI} from '../../models/response.interface'
import {TypesWashingI} from '../../models/types-washing/TypesWashing.interface'
import {TypesWashingService} from '../../service/types-washing/types-washing.service'

@Component({
  selector: 'app-types-washing',
  templateUrl: './types-washing.component.html',
  styleUrls: ['./types-washing.component.css']
})
export class TypesWashingComponent implements OnInit {

  typesWashingResponse:ResponseI;
  TypesWashing:TypesWashingI[];
  error_msg="";

  constructor(private router:Router,private api: TypesWashingService) { }

  ngOnInit(): void {
    
      this.api.getTypesWashing().subscribe(data =>{
        this.typesWashingResponse = data;
        if(this.typesWashingResponse.status=="ok"){
          this.TypesWashing = this.typesWashingResponse.result;
        }else{
          this.error_msg= "No se pudieron cargar los tipos de lavado"
        }
      })
    
  }

  viewTypeWashing(id:string){
    this.router.navigate(["viewTypeWashing", id])
  }

  newTypeWashing(){
    this.router.navigate(["newTypeWashing"])
  }

}
