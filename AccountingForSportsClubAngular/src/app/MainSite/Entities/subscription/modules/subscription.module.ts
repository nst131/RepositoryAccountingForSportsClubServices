import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { SubscriptionComponent } from "../subscription.component";
import { UpdateSubscriptionComponent } from "../update-subscription/update-subscription.component";
import { SubscriptionRoutingModule } from "./subscription-routing.module";

@NgModule({
      declarations: [
          SubscriptionComponent,
          UpdateSubscriptionComponent,
      ],
      imports: [
          SubscriptionRoutingModule,
  
          CommonModule,// is a feature module from BrouserModule(*ngIf and a lot of more)
          FormsModule,
          ReactiveFormsModule,
      ]
  })
  export class SubscriptionModule { }