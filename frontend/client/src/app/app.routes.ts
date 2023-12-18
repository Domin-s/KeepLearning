import { Routes } from '@angular/router';
import { StartComponent } from './start/start.component';
import { ListOfCountriesComponent } from './country/components/countries/list-of-country/list-of-country.component';
import { GenerateExamComponent } from './country/components/exam/generate-exam/generate-exam.component';

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
      children: [
        {
          title: "Generate exam",
          path: "generateExam",
          component: GenerateExamComponent
        },
      ]
    },
    {
      path: "**",
      redirectTo: "",
      pathMatch: "full",
    },
];
