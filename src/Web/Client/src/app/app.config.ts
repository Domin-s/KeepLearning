import { ApplicationConfig } from "@angular/core";
import { provideHttpClient } from "@angular/common/http";
import { Routes, provideRouter, withComponentInputBinding } from "@angular/router";
import { ListOfCountriesComponent } from "./country/components/list-of-countries/list-of-countries.component";
import { StartComponent } from "./start/start.component";

const routes: Routes = [
  {
    title: "Main",
    path: "",
    component: StartComponent,
  },
  {
    title: "Country",
    path: "country",
    component: ListOfCountriesComponent,
  },
  {
    path: "**",
    redirectTo: "",
    pathMatch: "full",
  },
];

export const appConfig: ApplicationConfig = {
  providers: [provideHttpClient(), provideRouter(routes, withComponentInputBinding())],
};
