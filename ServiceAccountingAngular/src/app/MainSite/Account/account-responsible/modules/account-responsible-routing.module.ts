import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { PageNotFoundComponentComponent } from "src/app/page-not-found-component/page-not-found-component.component";
import { AccountResponsibleComponent } from "../account-responsible.component";
import { CreateDealComponent } from "../create-deal/create-deal.component";
import { CreateVisitComponent } from "../create-visit/create-visit.component";
import { DealComponent } from "../deal/deal.component";
import { UpdateDealComponent } from "../update-deal/update-deal.component";
import { UpdateVisitComponent } from "../update-visit/update-visit.component";
import { VisitComponent } from "../visit/visit.component";

const routes: Routes = [
    {
        path: '', component: AccountResponsibleComponent,

        children: [
            {
                path: 'create-visit', component: CreateVisitComponent, outlet: 'account'
            },
            {
                path: 'create-deal', component: CreateDealComponent, outlet: 'account'
            },
            {
                path: 'update-deal/:id', component: UpdateDealComponent, outlet: 'account'
            },
            {
                path: 'update-visit/:id', component: UpdateVisitComponent, outlet: 'account'
            },
            {
                path: 'deal', component: DealComponent, outlet: 'account'
            },
            {
                path: 'visit', component: VisitComponent, outlet: 'account'
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
export class AccountResponsibleRoutingModule { }