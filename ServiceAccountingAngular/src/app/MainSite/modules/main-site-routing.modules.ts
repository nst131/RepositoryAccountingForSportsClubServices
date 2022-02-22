import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AuthGuardService } from "src/app/Auth/services/auth-guard.service";
import { PageNotFoundComponentComponent } from "src/app/page-not-found-component/page-not-found-component.component";
import { MainSiteComponent } from "../main-site/main-site.component";

const routes: Routes = [
    {path: '', component: MainSiteComponent,
    canActivateChild:[AuthGuardService],
    children:[
        {
            path: 'user', loadChildren: () => import("../Entities/user/modules/user.modules").then(mod => mod.UserModule), outlet: 'main-site',
        },
        {
            path: 'trainer', loadChildren: () => import("../Entities/trainer/modules/trainer.modules").then(mod => mod.TrainerModule), outlet: 'main-site',
        },
        {
            path: 'responsible', loadChildren: () => import("../Entities/responsible/modules/responsible.modules").then(mod => mod.ResponsibleModule), outlet: 'main-site',
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