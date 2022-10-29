import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component'
import { ConnectionTestComponent } from './components/connection-test/connection-test.component'
import { LoginAdminComponent } from './components/login-admin/login-admin.component'
import { LoginClientComponent } from './components/login-client/login-client.component'
import { HomeAdminComponent } from './components/home-admin/home-admin.component'
import { WorkersComponent } from './components/workers/workers.component'
import { ViewWorkerComponent } from './components/view-worker/view-worker.component'
import { NewWorkerComponent } from './components/new-worker/new-worker.component'
import { EditWorkerComponent } from './components/edit-worker/edit-worker.component'
import { ClientsComponent } from './components/clients/clients.component'
import { ViewClientComponent } from './components/view-client/view-client.component';
import { EditClientComponent } from './components/edit-client/edit-client.component';
import { NewClientComponent } from './components/new-client/new-client.component';
import { BranchesComponent } from './components/branches/branches.component';
import { ViewBranchComponent } from './components/view-branch/view-branch.component';
import { EditBranchComponent } from './components/edit-branch/edit-branch.component';
import { NewBranchComponent } from './components/new-branch/new-branch.component';
import { ProvidersComponent } from './components/providers/providers.component';
import { ViewProviderComponent } from './components/view-provider/view-provider.component';
import { EditProviderComponent } from './components/edit-provider/edit-provider.component';
import { NewProviderComponent } from './components/new-provider/new-provider.component';
import { TypesWashingComponent } from './components/types-washing/types-washing.component';
import { ViewTypesWashingComponent } from './components/view-types-washing/view-types-washing.component';
import { EditTypesWashingComponent } from './components/edit-types-washing/edit-types-washing.component';
import { NewTypesWashingComponent } from './components/new-types-washing/new-types-washing.component';
import { ProductsSuppliesComponent } from './components/products-supplies/products-supplies.component';
import { ViewProductComponent } from './components/view-product/view-product.component';
import { EditProductComponent } from './components/edit-product/edit-product.component';
import { NewProductComponent } from './components/new-product/new-product.component';
import { AppointmentsComponent } from './components/appointments/appointments.component';
import { ViewAppointmentComponent } from './components/view-appointment/view-appointment.component';
import { EditAppointmentComponent } from './components/edit-appointment/edit-appointment.component';
import { NewAppointmentComponent } from './components/new-appointment/new-appointment.component';
import { HomeClientComponent } from './components/home-client/home-client.component';


const routes: Routes = [
  {path:'', component:HomeComponent},
  {path:'loginAdmin',component:LoginAdminComponent},
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
  {path:'providers', component:ProvidersComponent},
  {path:'viewProvider/:id',component:ViewProviderComponent},
  {path:'editProvider/:id',component:EditProviderComponent},
  {path:'newProvider',component:NewProviderComponent},
  {path:'typesWashing', component:TypesWashingComponent},
  {path:'viewTypeWashing/:id',component:ViewTypesWashingComponent},
  {path:'editTypeWashing/:id',component:EditTypesWashingComponent},
  {path:'newTypeWashing',component:NewTypesWashingComponent},
  {path:'products', component:ProductsSuppliesComponent},
  {path:'viewProduct/:id',component:ViewProductComponent},
  {path:'editProduct/:id',component:EditProductComponent},
  {path:'newProduct',component:NewProductComponent},
  {path:'appointments', component:AppointmentsComponent},
  {path:'viewAppointment/:id',component:ViewAppointmentComponent},
  {path:'editAppointment/:id',component:EditAppointmentComponent},
  {path:'newAppointment',component:NewAppointmentComponent},

  {path:'loginClient',component:LoginClientComponent},
  {path:'homeClient',component:HomeClientComponent},
  
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
  ViewBranchComponent,EditBranchComponent,NewBranchComponent,ProvidersComponent,ViewProviderComponent,
  EditProviderComponent,NewProviderComponent,TypesWashingComponent,ViewTypesWashingComponent,
  EditTypesWashingComponent,NewTypesWashingComponent,ProductsSuppliesComponent,ViewProductComponent,
  EditProductComponent,NewProductComponent,AppointmentsComponent,ViewAppointmentComponent,
  EditAppointmentComponent,NewAppointmentComponent,
  HomeClientComponent]