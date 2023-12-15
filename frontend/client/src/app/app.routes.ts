import { Routes } from '@angular/router';
import { StartComponent } from './start/start.component';
import { ListOfCountriesComponent } from './country/components/list-of-country/list-of-country.component';

export const routes: Routes = [
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
