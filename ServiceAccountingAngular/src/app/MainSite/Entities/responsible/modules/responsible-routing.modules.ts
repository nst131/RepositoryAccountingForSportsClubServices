import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { PageNotFoundComponentComponent } from "src/app/page-not-found-component/page-not-found-component.component";
import { ResponsibleUpdateComponent } from "../responsible-update/responsible-update.component";
import { ResponsibleComponent } from "../responsible.component";

const routes: Routes = [
      { 
          path: '', component: ResponsibleComponent,
      },
      {
          path: 'edit-responsible/:id', component: ResponsibleUpdateComponent,
      },
      {
          path: '**', component: PageNotFoundComponentComponent,
      }
  ]
  
  
  @NgModule({
      imports: [RouterModule.forChild(routes)],
      exports: [RouterModule]
  })
  export class ResponsibleRoutingModule { }