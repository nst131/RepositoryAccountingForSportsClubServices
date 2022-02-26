import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { PageNotFoundComponentComponent } from "src/app/page-not-found-component/page-not-found-component.component";
import { AccountAdminComponent } from "../account-admin.component";
import { CreateClubCardComponent } from "../create-club-card/create-club-card.component";
import { CreatePlaceComponent } from "../create-place/create-place.component";
import { CreateServeComponent } from "../create-serve/create-serve.component";
import { CreateSubscriptionComponent } from "../create-subscription/create-subscription.component";
import { RegistrationAsAdminComponent } from "../registration-as-admin/registration-as-admin.component";

const routes: Routes = [
    {
        path: '', component: AccountAdminComponent,
        
        children: [
            {
                path: 'registration-as-admin', component: RegistrationAsAdminComponent, outlet: 'account'
            },
            {
                path: 'create-serve', component: CreateServeComponent, outlet: 'account'
            },
            {
                path: 'create-club-card', component: CreateClubCardComponent, outlet: 'account'
            },
            {
                path: 'create-subscription', component: CreateSubscriptionComponent, outlet: 'account'
            },
            {
                path: 'create-place', component: CreatePlaceComponent, outlet: 'account'
            },
            {
                path: '**', component: PageNotFoundComponentComponent, outlet: 'account'
            }
        ]
    }
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class AccountAdminRoutingModule { }