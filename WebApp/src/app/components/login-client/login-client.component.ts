import { Component, OnInit } from '@angular/core';

import {FormGroup, FormControl, Validators} from '@angular/forms'
import {LoginService} from '../../service/login/login.service'
import {Router} from '@angular/router'
import {LoginI} from '../../models/login/login.interface'
import {ResponseI} from '../../models/response.interface'
import { computeMsgId } from '@angular/compiler';

@Component({
  selector: 'app-login-client',
  templateUrl: './login-client.component.html',
  styleUrls: ['./login-client.component.css']
})
export class LoginClientComponent implements OnInit {

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
        this.router.navigate(['dashboard']);//redireccionara al home del cliente
      }else{
        this.errorStatus= true;
        this.errorMsj = "Credenciales invalidas";
      }
    })
  }

}
