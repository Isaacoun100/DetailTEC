import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  userSection:string

  constructor() { }

  ngOnInit(): void {

    let user = this.getUser();
    if(user == "client"){
      this.userSection = "client"
    }else{
      this.userSection = "admin"
    }
  }

  getUser(){
    return localStorage.getItem('user');
  }

}
