import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { ServeUpdateComponent } from "../serve-update/serve-update.component";
import { ServeComponent } from "../serve.component";
import { ServeRoutingModule } from "./serve-routing.module";

@NgModule({
    declarations: [
        ServeComponent,
        ServeUpdateComponent,
    ],
    imports: [
        ServeRoutingModule,

        CommonModule,// is a feature module from BrouserModule(*ngIf and a lot of more)
        FormsModule,
        ReactiveFormsModule,
    ]
})
export class ServeModule { }