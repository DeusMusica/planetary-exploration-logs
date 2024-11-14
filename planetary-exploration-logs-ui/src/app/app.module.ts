import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule, provideHttpClient, withFetch } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { DiscoveryComponent } from './pages/discovery/discovery.component';
import { CreateMissionComponent } from './pages/mission/create-mission/create-mission.component';
import { AddDiscoveryComponent } from './pages/discovery/add-discovery/add-discovery.component';
import { EditDiscoveryComponent } from './pages/discovery/edit-discovery/edit-discovery.component';
import { MissionComponent } from './pages/mission/mission.component';
import { EditMissionComponent } from './pages/mission/edit-mission/edit-mission/edit-mission.component';

@NgModule({
  declarations: [
    AppComponent,
    AddDiscoveryComponent,
    EditDiscoveryComponent,
    DiscoveryComponent,
    CreateMissionComponent,
    MissionComponent,
    EditMissionComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    RouterModule.forRoot([])
  ],
  providers: [
    provideHttpClient(withFetch())
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
