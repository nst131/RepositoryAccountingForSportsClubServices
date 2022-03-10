import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { PageNotFoundComponentComponent } from "src/app/page-not-found-component/page-not-found-component.component";
import { ClubCardComponent } from "../club-card.component";
import { UpdateClubCardComponent } from "../update-club-card/update-club-card.component";

const routes: Routes = [
      { 
          path: '', component: ClubCardComponent,
      },
      {
          path: 'edit-club-card/:id', component: UpdateClubCardComponent,
      },
      {
          path: '**', component: PageNotFoundComponentComponent,
      }
  ]
  
  
  @NgModule({
      imports: [RouterModule.forChild(routes)],
      exports: [RouterModule]
  })
  export class ClubCardRoutingModule { }