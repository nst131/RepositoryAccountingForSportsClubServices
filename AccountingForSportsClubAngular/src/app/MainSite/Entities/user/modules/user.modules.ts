import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { EditUserComponent } from "../edit-user/edit-user.component";
import { UserComponent } from "../user.component";
import { UserRoutingModule } from "./user-routing.modules";

@NgModule({
    declarations: [
        UserComponent,
        EditUserComponent,
    ],
    imports: [
        UserRoutingModule,

        CommonModule,// is a feature module from BrouserModule(*ngIf and a lot of more)
        FormsModule,
        ReactiveFormsModule,
    ]
  })
  export class UserModule { }