import { Routes } from "@angular/router";
import { HomeComponent } from "./home/home.component";
import { SurveyPageComponent } from "./survey-page/survey-page.component";
import { ClassesComponent } from "./classes/classes.component";

const routeConfig: Routes = [
    {
        path: '',
        component: HomeComponent,
        title: 'Home Page',
    },
    {
        path: 'survey-page',
        component: SurveyPageComponent,
        title: 'Survey Page',
    },
    {
        path: 'classes-page',
        component: ClassesComponent,
        title: 'Classes',
    },
];

export default routeConfig;