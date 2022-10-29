import { Component, OnInit } from '@angular/core';
import {ClientsService} from '../../service/clients/clients.service'
import {ClientRequestI} from '../../models/clients/clientRequest.interface'
import {ClientPointsI} from '../../models/clients/clientPoints.interface'
import {ResponseI} from '../../models/response.interface'


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  userSection:string
  pointsResposnse:ResponseI
  points:ClientPointsI
  clientRequest:ClientRequestI
  token:string | null

  constructor(private api:ClientsService) { }

  ngOnInit(): void {

    
    this.token = this.getToken()
    let user = this.getUser();
    this.clientRequest = {"cedula":this.token}
    
    if(user == "client"){
      this.userSection = "client"
    }else{
      this.userSection = "admin"
    }

    if(user == "client"){
      this.api.getPoints(this.clientRequest).subscribe(data => {
        this.pointsResposnse = data;
        if(this.pointsResposnse.status == 'ok'){
          this.points = data.result
        }
      })
    }
  }

  getUser(){
    return localStorage.getItem('user');
  }

  getToken(){
    return localStorage.getItem('token');
  }
}
