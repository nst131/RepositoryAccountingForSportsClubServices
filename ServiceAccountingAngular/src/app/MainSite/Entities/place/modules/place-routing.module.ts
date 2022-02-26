import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { PageNotFoundComponentComponent } from "src/app/page-not-found-component/page-not-found-component.component";
import { PlaceComponent } from "../place.component";
import { UpdatePlaceComponent } from "../update-place/update-place.component";

const routes: Routes = [
      { 
          path: '', component: PlaceComponent,
      },
      {
          path: 'edit-place/:id', component: UpdatePlaceComponent,
      },
      {
          path: '**', component: PageNotFoundComponentComponent,
      }
  ]
  
  
  @NgModule({
      imports: [RouterModule.forChild(routes)],
      exports: [RouterModule]
  })
  export class PlaceRoutingModule { }