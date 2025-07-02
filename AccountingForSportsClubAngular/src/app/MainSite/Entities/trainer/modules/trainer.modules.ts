import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { TrainerUpdateComponent } from "../trainer-update/trainer-update.component";
import { TrainerComponent } from "../trainer.component";
import { TrainerRoutingModule } from "./trainer-routing.modules";

@NgModule({
      declarations: [
          TrainerComponent,
          TrainerUpdateComponent,
      ],
      imports: [
          TrainerRoutingModule,
  
          CommonModule,// is a feature module from BrouserModule(*ngIf and a lot of more)
          FormsModule,
          ReactiveFormsModule
      ]
    })
    export class TrainerModule { }