import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { PageNotFoundComponentComponent } from "src/app/page-not-found-component/page-not-found-component.component";
import { AccountUserComponent } from "../account-user.component";

const routes: Routes = [
      { 
          path: '', component: AccountUserComponent,
      },
      {
          path: '**', component: PageNotFoundComponentComponent,
      }
  ]
  
  @NgModule({
      imports: [RouterModule.forChild(routes)],
      exports: [RouterModule]
  })
  export class AccountUserRoutingModule { }