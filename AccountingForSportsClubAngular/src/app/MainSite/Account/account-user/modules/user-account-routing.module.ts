import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { PageNotFoundComponentComponent } from "src/app/page-not-found-component/page-not-found-component.component";
import { AccountUserComponent } from "../account-user.component";
import { DealsInfComponent } from "../deals-inf/deals-inf.component";
import { SubscriptionsInfComponent } from "../subscriptions-inf/subscriptions-inf.component";
import { TrainingsInfComponent } from "../trainings-inf/trainings-inf.component";
import { VisitsInfComponent } from "../visits-inf/visits-inf.component";

const routes: Routes = [
    {
        path: '', component: AccountUserComponent,

        children: [
            {
                path: 'dealsInf/:id', component: DealsInfComponent, outlet: 'account'
            },
            {
                path: 'subscriptionsInf/:id', component: SubscriptionsInfComponent, outlet: 'account'
            },
            {
                path: 'trainingsInf/:id', component: TrainingsInfComponent, outlet: 'account'
            },
            {
                path: 'visitsInf/:id', component: VisitsInfComponent, outlet: 'account'
            },
        ]
    },
    {
        path: '**', component: PageNotFoundComponentComponent,
    }
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class AccountUserRoutingModule { }