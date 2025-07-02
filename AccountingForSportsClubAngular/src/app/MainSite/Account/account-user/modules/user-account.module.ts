import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { AccountUserComponent } from "../account-user.component";
import { DealsInfComponent } from "../deals-inf/deals-inf.component";
import { SubscriptionsInfComponent } from "../subscriptions-inf/subscriptions-inf.component";
import { TrainingsInfComponent } from "../trainings-inf/trainings-inf.component";
import { VisitsInfComponent } from "../visits-inf/visits-inf.component";
import { AccountUserRoutingModule } from "./user-account-routing.module";

@NgModule({
    declarations: [
        AccountUserComponent,
        DealsInfComponent,
        SubscriptionsInfComponent,
        TrainingsInfComponent,
        VisitsInfComponent
    ],
    imports: [
        AccountUserRoutingModule,

        CommonModule,// is a feature module from BrouserModule(*ngIf and a lot of more)
        //     FormsModule,
        //     ReactiveFormsModule,
    ]
})
export class AccountUserModule { }