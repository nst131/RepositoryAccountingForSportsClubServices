import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { ClubCardComponent } from "../club-card.component";
import { UpdateClubCardComponent } from "../update-club-card/update-club-card.component";
import { ClubCardRoutingModule } from "./club-card-routing.module";

@NgModule({
      declarations: [
          ClubCardComponent,
          UpdateClubCardComponent,
      ],
      imports: [
          ClubCardRoutingModule,
  
          CommonModule,// is a feature module from BrouserModule(*ngIf and a lot of more)
          FormsModule,
          ReactiveFormsModule,
      ]
  })
  export class ClubCardModule { }