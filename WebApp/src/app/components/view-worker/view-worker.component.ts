import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import {SingleWorkerI} from '../../models/workers/singleWorker.interface'
import {WorkerRequestI} from '../../models/workers/workerRequest.interface'
import {ResponseI} from '../../models/response.interface'
import {WorkersService} from '../../service/workers/workers.service'


@Component({
  selector: 'app-view-worker',
  templateUrl: './view-worker.component.html',
  styleUrls: ['./view-worker.component.css']
})
export class ViewWorkerComponent implements OnInit {

  constructor(private activerouter:ActivatedRoute, private router:Router,
    private api:WorkersService) { }

  workerInfoResponse:ResponseI;
  workerInfo:SingleWorkerI;
  workerRequest:WorkerRequestI;

  ngOnInit(): void {

    let workerId = this.activerouter.snapshot.paramMap.get('id');
    this.workerRequest.cedula = workerId

    this.api.getSingleWorker(this.workerRequest).subscribe(data =>{
      this.workerInfoResponse = data;
      if(this.workerInfoResponse.status == "ok"){
        this.workerInfo = this.workerInfoResponse.result;
      }else{
        alert("No se pudo cargar el trabajador")
      }
    })
  }


  edit(){
    this.router.navigate(["editWorker", this.activerouter.snapshot.paramMap.get('id')])
  }

  delete(){
    this.api.deleteEmployee(this.workerRequest)
  }

  exit(){
    this.router.navigate(["workers"])
  }
}
