import { Routes } from "@angular/router";
import { HomeComponent } from "./home/home.component";
import { SurveyPageComponent } from "./survey-page/survey-page.component";

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
];

export default routeConfig;