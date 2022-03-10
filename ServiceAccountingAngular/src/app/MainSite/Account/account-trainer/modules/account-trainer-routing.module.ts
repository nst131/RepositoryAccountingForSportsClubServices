import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { PageNotFoundComponentComponent } from "src/app/page-not-found-component/page-not-found-component.component";
import { AccountTrainerComponent } from "../account-trainer.component";
import { CreateTrainingByClientCardComponent } from "../create-training-by-client-card/create-training-by-client-card.component";
import { CreateTrainingBySubscriptionComponent } from "../create-training-by-subscription/create-training-by-subscription.component";
import { TrainingComponent } from "../training/training.component";
import { UpdateTrainingByClientCardComponent } from "../update-training-by-client-card/update-training-by-client-card.component";

const routes: Routes = [
    {
        path: '', component: AccountTrainerComponent,

        children: [
            {
                path: 'create-training-by-client-card', component: CreateTrainingByClientCardComponent, outlet: 'account'
            },
            {
                path: 'create-training-by-subscription', component: CreateTrainingBySubscriptionComponent, outlet: 'account'
            },
            {
                path: 'trainings', component: TrainingComponent, outlet: 'account'
            },
            {
                path: 'update-training-by-client-card/:id', component: UpdateTrainingByClientCardComponent, outlet: 'account'
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
export class AccountTrainerRoutingModule { }