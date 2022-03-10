import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { MatButtonModule } from "@angular/material/button";
import { AccountTrainerComponent } from "../account-trainer.component";
import { CreateTrainingByClientCardComponent } from "../create-training-by-client-card/create-training-by-client-card.component";
import { CreateTrainingBySubscriptionComponent } from "../create-training-by-subscription/create-training-by-subscription.component";
import { TrainingComponent } from "../training/training.component";
import { UpdateTrainingByClientCardComponent } from "../update-training-by-client-card/update-training-by-client-card.component";
import { AccountTrainerRoutingModule } from "./account-trainer-routing.module";
import {MatSelectModule} from '@angular/material/select';

@NgModule({
      declarations: [
            AccountTrainerComponent,
            CreateTrainingByClientCardComponent,
            CreateTrainingBySubscriptionComponent,
            UpdateTrainingByClientCardComponent,
            TrainingComponent
      ],
      imports: [
          AccountTrainerRoutingModule,
  
          CommonModule,// is a feature module from BrouserModule(*ngIf and a lot of more)
          FormsModule,
          ReactiveFormsModule,

          MatButtonModule,
          MatSelectModule
      ]
    })
    export class AccountTrainerModule { }