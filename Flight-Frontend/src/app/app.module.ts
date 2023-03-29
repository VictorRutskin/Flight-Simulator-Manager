import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FlightsComponent } from './flights/flights.component';
import { StartSimulationButtonComponent } from './start-button/start-button.component';
import { UiContainerComponent } from './ui-container/ui-container.component';

@NgModule({
  declarations: [
    AppComponent,
    FlightsComponent,
    StartSimulationButtonComponent,
    UiContainerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
