import { Component, OnInit } from '@angular/core';
import {FormGroup, FormControl, Validators} from '@angular/forms'
import {SingleWorkerI} from '../../models/workers/singleWorker.interface'
import {WorkersService} from '../../service/workers/workers.service'
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-new-worker',
  templateUrl: './new-worker.component.html',
  styleUrls: ['./new-worker.component.css']
})
export class NewWorkerComponent implements OnInit {

  constructor(private activerouter:ActivatedRoute, private router:Router,
    private api:WorkersService) { }

  newForm = new FormGroup({
    nombre: new FormControl(''),
    apellidos: new FormControl(''),
    cedula: new FormControl(''),
    fechaIngreso: new FormControl(''),
    fechaNacimiento: new FormControl(''),
    edad: new FormControl(''),
    password: new FormControl(''),
    rol:new FormControl(''),
    tipoPago: new FormControl('')
})

  ngOnInit(): void {
  }

  postForm(form:SingleWorkerI){
    this.api.postEmployee(form);
    this.newForm.reset();
  }

  exit(){
    this.router.navigate(["workers"])
  }
}
