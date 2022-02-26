import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { AccountUserComponent } from "../account-user.component";
import { AccountUserRoutingModule } from "./user-account-routing.module";

@NgModule({
      declarations: [
          AccountUserComponent
      ],
      imports: [
          AccountUserRoutingModule,
  
          CommonModule,// is a feature module from BrouserModule(*ngIf and a lot of more)
      //     FormsModule,
      //     ReactiveFormsModule,
      ]
    })
    export class AccountUserModule { }