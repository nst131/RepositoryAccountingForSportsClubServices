import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { PageNotFoundComponentComponent } from "src/app/page-not-found-component/page-not-found-component.component";
import { SubscriptionComponent } from "../subscription.component";
import { UpdateSubscriptionComponent } from "../update-subscription/update-subscription.component";

const routes: Routes = [
      { 
          path: '', component: SubscriptionComponent,
      },
      {
          path: 'edit-subscription/:id', component: UpdateSubscriptionComponent,
      },
      {
          path: '**', component: PageNotFoundComponentComponent,
      }
  ]
  
  
  @NgModule({
      imports: [RouterModule.forChild(routes)],
      exports: [RouterModule]
  })
  export class SubscriptionRoutingModule { }