import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router'
import {ResponseI} from '../../models/response.interface'
import {WorkersI} from '../../models/workers/workers.interface'
import {WorkersService} from '../../service/workers/workers.service'

@Component({
  selector: 'app-workers',
  templateUrl: './workers.component.html',
  styleUrls: ['./workers.component.css']
})
export class WorkersComponent implements OnInit {

  workersResponse:ResponseI;
  workers:WorkersI[];
  error_msg="";

  constructor(private router:Router,private api: WorkersService) { }

  ngOnInit(): void {
    
      this.api.getWorkers().subscribe(data =>{
        this.workersResponse = data;
        if(this.workersResponse.status=="ok"){
          this.workers = this.workersResponse.result;
        }else{
          this.error_msg= "No se pudieron cargar los trabajadores"
        }
      })
    
  }

  viewWorker(id:number){
    this.router.navigate(["viewWorker", id])
  }

  newWorker(){
    this.router.navigate(["newWorker"])
  }

}
