import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ListOfCountriesComponent } from './country/components/list-of-countries/list-of-countries.component';
import { TableOfCountriesComponent } from './country/components/table-of-countries/table-of-countries.component';

@NgModule({
  declarations: [
  ],
  imports: [
    AppComponent,
    AppRoutingModule,
    BrowserModule, 
    HttpClientModule,
    NgbModule,
    ListOfCountriesComponent,
    TableOfCountriesComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
