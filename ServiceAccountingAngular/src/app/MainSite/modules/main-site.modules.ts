import { NgModule } from "@angular/core";
import { MainPageComponent } from "../main-page/main-page.component";
import { MainSiteComponent } from "../main-site/main-site.component";
import { MainSiteRoutingModule } from "./main-site-routing.modules";

@NgModule({
    declarations: [
        MainSiteComponent,
        MainPageComponent
    ],
    imports: [
      MainSiteRoutingModule
    ]
  })
  export class MainSiteModule { }