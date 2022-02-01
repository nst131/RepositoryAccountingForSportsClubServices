import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { PageNotFoundComponentComponent } from "src/app/page-not-found-component/page-not-found-component.component";
import { MainPageComponent } from "../main-page/main-page.component";
import { MainSiteComponent } from "../main-site/main-site.component";

const routes: Routes = [
    {path: '', component: MainSiteComponent,
    children:[
        {
            path: '', redirectTo: 'main-page', pathMatch:'full'
        },
        {
            path: 'main-page', component: MainPageComponent, outlet:'main-site'
        },
        {
            path: '**', component: PageNotFoundComponentComponent, outlet:'main-site'
        }
    ]
}]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class MainSiteRoutingModule { }