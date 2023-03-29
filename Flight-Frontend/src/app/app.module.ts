import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FlightsComponent } from './Components/flights/flights.component';
import { StartSimulationButtonComponent } from './Components/start-button/start-button.component';
import { UiContainerComponent } from './Components/ui-container/ui-container.component';
import { ConsoleComponent } from './Components/console/console.component';

@NgModule({
  declarations: [
    AppComponent,
    FlightsComponent,
    StartSimulationButtonComponent,
    UiContainerComponent,
    ConsoleComponent,
  ],
  imports: [BrowserModule, AppRoutingModule, HttpClientModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
