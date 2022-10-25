import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import {SingleBranchI} from '../../models/branches/singleBranch.interface'
import {BranchesService} from '../../service/branches/branches.service'
import {FormGroup, FormControl} from '@angular/forms'

@Component({
  selector: 'app-new-branch',
  templateUrl: './new-branch.component.html',
  styleUrls: ['./new-branch.component.css']
})
export class NewBranchComponent implements OnInit {

  constructor(private activerouter:ActivatedRoute, private router:Router,
    private api:BranchesService) { }

  newForm = new FormGroup({
    nombre: new FormControl(''),
    fechaInicioGerente: new FormControl(''),
    ubicacion: new FormControl(''),
    gerente: new FormControl(''),
    telefono: new FormControl('')
}) 

  ngOnInit(): void {
  }

  postForm(form:SingleBranchI){
    this.api.poatBranch(form);
    this.newForm.reset();
  }

  exit(){
    this.router.navigate(["branches"])
  }

}
