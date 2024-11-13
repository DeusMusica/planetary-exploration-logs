import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MissionComponent } from './mission.component';
import { CreateMissionComponent } from './create-mission/create-mission.component';

const routes: Routes = [
  { path: '', component: MissionComponent },
  { path: 'create', component: CreateMissionComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MissionRoutingModule { }
