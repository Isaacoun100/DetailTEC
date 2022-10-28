import { Component, OnInit } from '@angular/core';

import {FormGroup, FormControl, Validators} from '@angular/forms'
import {LoginService} from '../../service/login/login.service'
import {Router} from '@angular/router'
import {LoginI} from '../../models/login/login.interface'
import {ResponseI} from '../../models/response.interface'

@Component({
  selector: 'app-login-admin',
  templateUrl: './login-admin.component.html',
  styleUrls: ['./login-admin.component.css']
})
export class LoginAdminComponent implements OnInit {

  loginForm = new FormGroup({
    correo: new FormControl('', Validators.required),
    contrasena: new FormControl('', Validators.required)
  })

  constructor(private api: LoginService, private router:Router) { }

  errorStatus:boolean =false;
  errorMsj:any = "";

  ngOnInit(): void {
  }

  onLogin(form:LoginI){
    this.api.loginByEmail(form).subscribe(data => {
      let dataResponse: ResponseI = data;
      if(dataResponse.status == "ok"){
        localStorage.setItem("token", data.result.cedula);
        this.router.navigate(['homeAdmin']);
        localStorage.setItem("user", "admin");
      }else{
        this.errorStatus= true;
        this.errorMsj = "Credenciales invalidas";
      }
    })
  }
}
