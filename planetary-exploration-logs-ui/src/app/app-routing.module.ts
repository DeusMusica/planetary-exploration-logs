import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddDiscoveryComponent } from './pages/discovery/add-discovery/add-discovery.component';
import { EditDiscoveryComponent } from './pages/discovery/edit-discovery/edit-discovery.component';
import { CreateMissionComponent } from './pages/mission/create-mission/create-mission.component';
import { MissionComponent } from './pages/mission/mission.component';

const routes: Routes = [
  { path: '', redirectTo: '/mission', pathMatch: 'full' }, // Default route  
  { path: 'mission', component: MissionComponent },
  { path: 'mission/create', component: CreateMissionComponent },
  { path: 'discovery/add', component: AddDiscoveryComponent },
  { path: 'discovery/edit/:discoveryId', component: EditDiscoveryComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
