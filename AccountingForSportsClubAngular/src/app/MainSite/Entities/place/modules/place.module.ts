import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { PlaceComponent } from "../place.component";
import { UpdatePlaceComponent } from "../update-place/update-place.component";
import { PlaceRoutingModule } from "./place-routing.module";

@NgModule({
      declarations: [
          PlaceComponent,
          UpdatePlaceComponent,
      ],
      imports: [
          PlaceRoutingModule,
  
          CommonModule,// is a feature module from BrouserModule(*ngIf and a lot of more)
          FormsModule,
          ReactiveFormsModule,
      ]
  })
  export class PlaceModule { }