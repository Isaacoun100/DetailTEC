import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router'
import {InformationTestI} from '../../interfaces/information-test.interface'
import {ApiConnectionTestService} from '../../service/test/api-connection-test.service'

@Component({
  selector: 'app-connection-test',
  templateUrl: './connection-test.component.html',
  styleUrls: ['./connection-test.component.css']
})
export class ConnectionTestComponent implements OnInit {

  information:InformationTestI[];

  constructor(private router:Router,private api: ApiConnectionTestService) { }

  ngOnInit(): void {
    this.api.getInformationTest().subscribe(data =>{
      this.information = data;
    })
  }
}
