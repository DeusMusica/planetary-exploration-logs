import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', redirectTo: '/mission', pathMatch: 'full' }, // Default route
  { path: 'discovery', loadChildren: () => import('./pages/discovery/discovery.module').then(m => m.DiscoveryModule) },
  { path: 'mission', loadChildren: () => import('./pages/mission/mission.module').then(m => m.MissionModule) },
  { path: 'planet', loadChildren: () => import('./pages/planet/planet.module').then(m => m.PlanetModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
