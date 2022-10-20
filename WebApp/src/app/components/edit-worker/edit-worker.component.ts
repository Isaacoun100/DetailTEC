import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import {SingleWorkerI} from '../../models/workers/singleWorker.interface'
import {WorkerRequestI} from '../../models/workers/workerRequest.interface'
import {ResponseI} from '../../models/response.interface'
import {WorkersService} from '../../service/workers/workers.service'
import {FormGroup, FormControl, Validators} from '@angular/forms'
import { HttpXsrfTokenExtractor } from '@angular/common/http';

@Component({
  selector: 'app-edit-worker',
  templateUrl: './edit-worker.component.html',
  styleUrls: ['./edit-worker.component.css']
})
export class EditWorkerComponent implements OnInit {

  constructor(private activerouter:ActivatedRoute, private router:Router,
    private api:WorkersService) { }

  workerInfoResponse:ResponseI;
  workerInfo:SingleWorkerI;
  workerRequest:WorkerRequestI;
  
  editForm = new FormGroup({
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

    let workerId = this.activerouter.snapshot.paramMap.get('id');
    this.workerRequest.cedula = workerId

    this.api.getSingleWorker(this.workerRequest).subscribe(data =>{
      this.workerInfoResponse = data;
      if(this.workerInfoResponse.status == "ok"){
        this.workerInfo = this.workerInfoResponse.result;
        this.editForm.setValue({
          'nombre' : this.workerInfo.nombre,
          'apellidos': this.workerInfo.apellidos,
          'cedula': this.workerInfo.cedula,
          'fechaIngreso': this.workerInfo.fechaIngreso,
          'fechaNacimiento': this.workerInfo.fechaNacimiento,
          'edad':this.workerInfo.edad,
          'password': this.workerInfo.password,
          'rol':this.workerInfo.rol,
          'tipoPago': this.workerInfo.tipoPago,
        })
      }else{
        alert("No se pudo cargar el trabajador")
      }})
      
  }

  putForm(form:SingleWorkerI){
    this.api.putEmployee(form);

  }

  exit(){
    this.router.navigate(["viewWorker", this.activerouter.snapshot.paramMap.get('id')])
  }


}
