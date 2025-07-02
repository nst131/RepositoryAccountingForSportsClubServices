import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { PageNotFoundComponentComponent } from "src/app/page-not-found-component/page-not-found-component.component";
import { TrainerUpdateComponent } from "../trainer-update/trainer-update.component";
import { TrainerComponent } from "../trainer.component";

const routes: Routes = [
      { 
          path: '', component: TrainerComponent,
      },
      {
          path: 'edit-trainer/:id', component: TrainerUpdateComponent,
      },
      {
          path: '**', component: PageNotFoundComponentComponent,
      }
  ]
  
  
  @NgModule({
      imports: [RouterModule.forChild(routes)],
      exports: [RouterModule]
  })
  export class TrainerRoutingModule { }