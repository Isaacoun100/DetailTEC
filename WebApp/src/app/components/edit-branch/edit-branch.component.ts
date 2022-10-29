import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import {SingleBranchI} from '../../models/branches/singleBranch.interface'
import {BranchRequestI} from '../../models/branches/branchRequest.interface'
import {ResponseI} from '../../models/response.interface'
import {BranchesService} from '../../service/branches/branches.service'
import {FormGroup, FormControl, Validators} from '@angular/forms'

@Component({
  selector: 'app-edit-branch',
  templateUrl: './edit-branch.component.html',
  styleUrls: ['./edit-branch.component.css']
})
export class EditBranchComponent implements OnInit {

  constructor(private activerouter:ActivatedRoute, private router:Router,
    private api:BranchesService) { }

  branchInfoResponse:ResponseI;
  branchRequest:BranchRequestI;
  branchInfo:SingleBranchI;
  
  editForm = new FormGroup({
    nombre: new FormControl(''),
    fechaInicioGerente: new FormControl(''),
    ubicacion: new FormControl(''),
    gerente: new FormControl(''),
    telefono: new FormControl('')
}) 

  ngOnInit(): void {

    let branchId = this.activerouter.snapshot.paramMap.get('id');
    this.branchRequest = {'branchName':branchId}

    this.api.getSingleBranch(this.branchRequest).subscribe(data =>{
      this.branchInfoResponse = data;
      if(this.branchInfoResponse.status == "ok"){
        this.branchInfo = data.result;
        this.editForm.setValue({
          'nombre' : this.branchInfo.nombre,
          'fechaInicioGerente': this.branchInfo.fechaInicioGerente,
          'ubicacion': this.branchInfo.ubicacion,
          'gerente': this.branchInfo.gerente,
          'telefono': this.branchInfo.telefono
        })
      }else{
        alert("No se pudo cargar la sucursal")
      }})
  }

  putForm(form:SingleBranchI){
    this.api.putBranch(form).subscribe();
    this.exit();
  }

  exit(){
    this.router.navigate(["viewBranch", this.activerouter.snapshot.paramMap.get('id')])
  }

}
