import { Routes } from '@angular/router';
import { StartComponent } from './start/start.component';
import { ListOfCountriesComponent } from './country/ui/countries/list-of-country/list-of-country.component';
import { GenerateExamComponent } from './country/ui/exam/generate-exam/generate-exam.component';
import { ResolveExamComponent } from './country/ui/exam/resolve-exam/resolve-exam.component';
import { GenerateQuestionComponent } from './country/ui/question/generate/generate-question.component';

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
      title: "Generate exam",
      path: "country/generateExam",
      component: GenerateExamComponent
    },
    {
      title: "Resolve exam",
      path: "country/resolveExam",
      component: ResolveExamComponent
    },
    {
      title: "Generate question",
      path: "country/generateQuestion",
      component: GenerateQuestionComponent
    },
    {
      path: "**",
      redirectTo: "",
      pathMatch: "full",
    },
];
