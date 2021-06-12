import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { baseUrl } from '@core';
import { SidenavModule } from '@shared/sidenav/sidenav.module';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    SidenavModule
  ],
  providers: [
    {
      provide: baseUrl,
      useValue: "http://localhost:5001/"
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
