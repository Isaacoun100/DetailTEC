import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {HomeComponent} from './components/home/home.component'
import {ConnectionTestComponent} from './components/connection-test/connection-test.component'
import {LoginAdminComponent} from './components/login-admin/login-admin.component'
import {LoginClientComponent} from './components/login-client/login-client.component'
import {HomeAdminComponent} from './components/home-admin/home-admin.component'
import {WorkersComponent} from './components/workers/workers.component'
import {ViewWorkerComponent} from './components/view-worker/view-worker.component'
import {NewWorkerComponent} from './components/new-worker/new-worker.component'
import {EditWorkerComponent} from './components/edit-worker/edit-worker.component'
import {ClientsComponent} from './components/clients/clients.component'
import {ViewClientComponent} from './components/view-client/view-client.component';
import {EditClientComponent} from './components/edit-client/edit-client.component';
import { NewClientComponent } from './components/new-client/new-client.component';
import { BranchesComponent } from './components/branches/branches.component';
import { ViewBranchComponent } from './components/view-branch/view-branch.component';
import { EditBranchComponent } from './components/edit-branch/edit-branch.component';
import { NewBranchComponent } from './components/new-branch/new-branch.component';


const routes: Routes = [
  {path:'', component:HomeComponent},
  {path:'loginAdmin',component:LoginAdminComponent},
  {path:'loginClient',component:LoginClientComponent},
  {path:'homeAdmin',component:HomeAdminComponent},
  {path:'workers',component:WorkersComponent},
  {path:'viewWorker/:id',component:ViewWorkerComponent},
  {path:'editWorker/:id',component:EditWorkerComponent},
  {path:'newWorker',component:NewWorkerComponent},
  {path:'clients', component:ClientsComponent},
  {path:'viewClient/:id',component:ViewClientComponent},
  {path:'editClient/:id',component:EditClientComponent},
  {path:'newClient',component:NewClientComponent},
  {path:'branches', component:BranchesComponent},
  {path:'viewBranch/:id',component:ViewBranchComponent},
  {path:'editBranch/:id',component:EditBranchComponent},
  {path:'newBranch',component:NewBranchComponent},
  {path:'test-info', component:ConnectionTestComponent},//TEST
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const routingComponents = [ConnectionTestComponent,HomeComponent,LoginAdminComponent,LoginClientComponent,
  HomeAdminComponent,WorkersComponent,ViewWorkerComponent,EditWorkerComponent,NewWorkerComponent,
  ClientsComponent,ViewClientComponent,EditClientComponent,NewClientComponent,BranchesComponent,
  ViewBranchComponent,EditBranchComponent,NewBranchComponent]