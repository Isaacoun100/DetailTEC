import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import {SingleTypeWashingI} from '../../models/types-washing/singleTypeWashing.interface'
import {TypesWashingService} from '../../service/types-washing/types-washing.service'
import {FormGroup, FormControl} from '@angular/forms'

@Component({
  selector: 'app-new-types-washing',
  templateUrl: './new-types-washing.component.html',
  styleUrls: ['./new-types-washing.component.css']
})
export class NewTypesWashingComponent implements OnInit {

  constructor(private activerouter:ActivatedRoute, private router:Router,
    private api:TypesWashingService) { 
      
    }
    
    newForm = new FormGroup({
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
    }
  
  
    postForm(form:SingleTypeWashingI){
      this.api.postTypeWashing(form).subscribe();
      this.newForm.reset()
    }
  
    exit(){
      this.router.navigate(["typesWashing"])
    }

}
