import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FlightsComponent } from './Components/flights/flights.component';
import { UiContainerComponent } from './Components/ui-container/ui-container.component';
import { ConsoleComponent } from './Components/console/console.component';
import { MainPageComponent } from './Pages/main-page/main-page.component';
import { ControllerComponent } from './Components/controller/controller.component';

@NgModule({
  declarations: [
    AppComponent,
    FlightsComponent,
    UiContainerComponent,
    ConsoleComponent,
    MainPageComponent,
    ControllerComponent,
  ],
  imports: [BrowserModule, AppRoutingModule, HttpClientModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
