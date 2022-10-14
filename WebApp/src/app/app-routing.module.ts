import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {ConnectionTestComponent} from './components/connection-test/connection-test.component'
import {HomeComponent} from './components/home/home.component'

const routes: Routes = [
  {path:'', component:HomeComponent},
  {path: 'test-info', component:ConnectionTestComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const routingComponents = [ConnectionTestComponent,HomeComponent]