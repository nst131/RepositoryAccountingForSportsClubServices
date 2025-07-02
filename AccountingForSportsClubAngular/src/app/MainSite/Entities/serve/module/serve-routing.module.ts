import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { PageNotFoundComponentComponent } from "src/app/page-not-found-component/page-not-found-component.component";
import { ServeUpdateComponent } from "../serve-update/serve-update.component";
import { ServeComponent } from "../serve.component";

const routes: Routes = [
      { 
          path: '', component: ServeComponent,
      },
      {
          path: 'edit-serve/:id', component: ServeUpdateComponent,
      },
      {
          path: '**', component: PageNotFoundComponentComponent,
      }
  ]
  
  
  @NgModule({
      imports: [RouterModule.forChild(routes)],
      exports: [RouterModule]
  })
  export class ServeRoutingModule { }