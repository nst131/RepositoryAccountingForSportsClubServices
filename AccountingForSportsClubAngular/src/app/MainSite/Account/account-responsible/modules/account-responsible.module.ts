import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { MatButtonModule } from "@angular/material/button";
import { AccountResponsibleComponent } from "../account-responsible.component";
import { CreateDealComponent } from "../create-deal/create-deal.component";
import { CreateVisitComponent } from "../create-visit/create-visit.component";
import { DealComponent } from "../deal/deal.component";
import { UpdateDealComponent } from "../update-deal/update-deal.component";
import { UpdateVisitComponent } from "../update-visit/update-visit.component";
import { VisitComponent } from "../visit/visit.component";
import { AccountResponsibleRoutingModule } from "./account-responsible-routing.module";

@NgModule({
      declarations: [
            AccountResponsibleComponent,
            CreateVisitComponent,
            CreateDealComponent,
            UpdateVisitComponent,
            UpdateDealComponent,
            DealComponent,
            VisitComponent
      ],
      imports: [
          AccountResponsibleRoutingModule,
  
          CommonModule,// is a feature module from BrouserModule(*ngIf and a lot of more)
          FormsModule,
          ReactiveFormsModule,

          MatButtonModule
      ]
    })
    export class AccountResponsibleModule { }