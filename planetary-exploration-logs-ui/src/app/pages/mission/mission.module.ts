import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MissionRoutingModule } from './mission-routing.module';
import { MissionComponent } from './mission.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [MissionComponent],
  imports: [
    CommonModule,
    MissionRoutingModule,
    FormsModule,
    RouterModule
  ],
  exports: [MissionComponent] // Export if needed in other modules
})
export class MissionModule {}