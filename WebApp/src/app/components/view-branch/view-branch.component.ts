import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import {ResponseI} from '../../models/response.interface'
import {SingleBranchI} from '../../models/branches/singleBranch.interface'
import {BranchRequestI} from '../../models/branches/branchRequest.interface'
import {BranchesService} from '../../service/branches/branches.service'

@Component({
  selector: 'app-view-branch',
  templateUrl: './view-branch.component.html',
  styleUrls: ['./view-branch.component.css']
})
export class ViewBranchComponent implements OnInit {

  constructor(private activerouter:ActivatedRoute, private router:Router,
    private api:BranchesService) { }

  branchInfoResponse:ResponseI;
  branchInfo:SingleBranchI = {
    "nombre":"",
    "fechaInicioGerente":"",
    "ubicacion":[],
    "gerente":"",
    "telefono":""
  }
  branchRequest:BranchRequestI;

  ngOnInit(): void {

    let branchId = this.activerouter.snapshot.paramMap.get('id');
    this.branchRequest = {"branchName":branchId}

    console.log(this.branchRequest);
    
    this.api.getSingleBranch(this.branchRequest).subscribe(data =>{
      this.branchInfoResponse = data;

      if(this.branchInfoResponse.status == "ok"){
        this.branchInfo = this.branchInfoResponse.result;
      }else{
        alert("No se pudo cargar la sucursal")
      }
    })
  }

  edit(){
    this.router.navigate(["editBranch", this.activerouter.snapshot.paramMap.get('id')])
  }

  delete(){
    this.api.deleteBranch(this.branchRequest).subscribe();
    this.exit()
  }

  exit(){
    this.router.navigate(["branches"])
  }

}
