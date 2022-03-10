import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { MainSiteGuardService } from "src/app/Auth/services/guard.service";
import { PageNotFoundComponentComponent } from "src/app/page-not-found-component/page-not-found-component.component";
import { MainSiteComponent } from "../main-site/main-site.component";

const routes: Routes = [
    {path: '', component: MainSiteComponent,
    canActivateChild:[MainSiteGuardService],
    children:[
        {
            path: 'account-admin', loadChildren: () => import("../Account/account-admin/modules/account-admin.module").then(mod => mod.AccountAdminModule), outlet: 'main-site',
        },
        {
            path: 'account-user', loadChildren: () => import("../Account/account-user/modules/user-account.module").then(mod => mod.AccountUserModule), outlet: 'main-site',
        },
        {
            path: 'account-responsible', loadChildren: () => import("../Account/account-responsible/modules/account-responsible.module").then(mod => mod.AccountResponsibleModule), outlet: 'main-site',
        },
        {
            path: 'account-trainer', loadChildren: () => import("../Account/account-trainer/modules/account-trainer.module").then(mod => mod.AccountTrainerModule), outlet: 'main-site',
        },
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
            path: 'service', loadChildren: () => import("../Entities/serve/module/serve.module").then(mod => mod.ServeModule), outlet: 'main-site',
        },
        {
            path: 'place', loadChildren: () => import("../Entities/place/modules/place.module").then(mod => mod.PlaceModule), outlet: 'main-site',
        },
        {
            path: 'club-card', loadChildren: () => import("../Entities/club-card/modules/club-card.module").then(mod => mod.ClubCardModule), outlet: 'main-site',
        },
        {
            path: 'subscription', loadChildren: () => import("../Entities/subscription/modules/subscription.module").then(mod => mod.SubscriptionModule), outlet: 'main-site',
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