import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { ResponsibleUpdateComponent } from "../responsible-update/responsible-update.component";
import { ResponsibleComponent } from "../responsible.component";
import { ResponsibleRoutingModule } from "./responsible-routing.modules";

@NgModule({
      declarations: [
            ResponsibleComponent,
            ResponsibleUpdateComponent,
      ],
      imports: [
            ResponsibleRoutingModule,

            CommonModule,// is a feature module from BrouserModule(*ngIf and a lot of more)
            FormsModule,
            ReactiveFormsModule
      ]
})
export class ResponsibleModule { }