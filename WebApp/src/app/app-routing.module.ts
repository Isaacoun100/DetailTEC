import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {ConnectionTestComponent} from './components/connection-test/connection-test.component'
import {HomeComponent} from './components/home/home.component'
import {LoginAdminComponent} from './components/login-admin/login-admin.component'
import {LoginClientComponent} from './components/login-client/login-client.component'

const routes: Routes = [
  {path:'', component:HomeComponent},
  {path:'loginAdmin',component:LoginAdminComponent},
  {path:'loginClient',component:LoginClientComponent},
  {path: 'test-info', component:ConnectionTestComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const routingComponents = [ConnectionTestComponent,HomeComponent,LoginAdminComponent,LoginClientComponent]