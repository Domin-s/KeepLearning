import { Routes } from '@angular/router';
import { StartComponent } from './start/start.component';

export const routes: Routes = [
    {
      title: "Main",
      path: "",
      component: StartComponent,
    },
    {
      path: "**",
      redirectTo: "",
      pathMatch: "full",
    },
];
