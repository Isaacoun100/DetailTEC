import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router'
import {ResponseI} from '../../models/response.interface'
import {BranchesI} from '../../models/branches/branches.interface'
import {BranchesService} from '../../service/branches/branches.service'

@Component({
  selector: 'app-branches',
  templateUrl: './branches.component.html',
  styleUrls: ['./branches.component.css']
})
export class BranchesComponent implements OnInit {

  branchesResponse:ResponseI;
  branches:BranchesI[];
  error_msg="";

  constructor(private router:Router,private api: BranchesService) { }

  ngOnInit(): void {
    this.api.getBranches().subscribe(data =>{
      this.branchesResponse = data;
      if(this.branchesResponse.status=="ok"){
        this.branches = this.branchesResponse.result;
      }else{
        this.error_msg= "No se pudieron cargar las sucursales"
      }
    })
  }

  viewBranch(id:string){
    this.router.navigate(["viewBranch", id])
  }

  newBranch(){
    this.router.navigate(["newBranch"])
  }
}
