import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { MatButtonModule } from "@angular/material/button";
import { AccountAdminComponent } from "../account-admin.component";
import { CreateClubCardComponent } from "../create-club-card/create-club-card.component";
import { CreatePlaceComponent } from "../create-place/create-place.component";
import { CreateServeComponent } from "../create-serve/create-serve.component";
import { CreateSubscriptionComponent } from "../create-subscription/create-subscription.component";
import { RegistrationAsAdminComponent } from "../registration-as-admin/registration-as-admin.component";
import { AccountAdminRoutingModule } from "./account-admin-routing.module";

@NgModule({
      declarations: [
          AccountAdminComponent,
          RegistrationAsAdminComponent,
          CreateServeComponent,
          CreatePlaceComponent,
          CreateSubscriptionComponent,
          CreateClubCardComponent
      ],
      imports: [
          AccountAdminRoutingModule,
  
          CommonModule,// is a feature module from BrouserModule(*ngIf and a lot of more)
          FormsModule,
          ReactiveFormsModule,

          MatButtonModule
      ]
    })
    export class AccountAdminModule { }