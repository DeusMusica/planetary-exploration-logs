import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DiscoveryRoutingModule } from './discovery-routing.module';
import { DiscoveryComponent } from './discovery.component';
import { FormsModule } from '@angular/forms';
import { EditDiscoveryComponent } from './edit-discovery/edit-discovery.component';


@NgModule({
  declarations: [
    DiscoveryComponent,
    EditDiscoveryComponent
  ],
  imports: [
    CommonModule,
    DiscoveryRoutingModule,
    FormsModule
  ]
})
export class DiscoveryModule { }
