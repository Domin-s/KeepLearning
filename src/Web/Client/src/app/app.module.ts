import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ListOfCountriesComponent } from './country/components/list-of-countries/list-of-countries.component';
import { RowCountryComponent } from './country/components/row-country/row-country.component';
import { TableOfCountriesComponent } from './country/components/table-of-countries/table-of-countries.component';

@NgModule({
  declarations: [
    AppComponent,
    ListOfCountriesComponent,
    RowCountryComponent,
    TableOfCountriesComponent
  ],
  imports: [
    AppRoutingModule,
    BrowserModule, 
    HttpClientModule,
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
