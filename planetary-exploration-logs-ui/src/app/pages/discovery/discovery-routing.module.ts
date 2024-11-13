import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DiscoveryComponent } from './discovery.component';
import { AddDiscoveryComponent } from './add-discovery/add-discovery.component';
import { EditDiscoveryComponent } from './edit-discovery/edit-discovery.component';

const routes: Routes = [
  { path: '', component: DiscoveryComponent },
  { path: 'add', component: AddDiscoveryComponent},
  { path: 'edit/:discoveryId', component: EditDiscoveryComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DiscoveryRoutingModule { }
