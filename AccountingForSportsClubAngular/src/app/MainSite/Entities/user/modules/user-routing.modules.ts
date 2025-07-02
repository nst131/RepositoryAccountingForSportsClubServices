import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { PageNotFoundComponentComponent } from "src/app/page-not-found-component/page-not-found-component.component";
import { EditUserComponent } from "../edit-user/edit-user.component";
import { UserComponent } from "../user.component";

const routes: Routes = [
    { 
        path: '', component: UserComponent,
    },
    {
        path: 'edit-user/:id', component: EditUserComponent,
    },
    {
        path: '**', component: PageNotFoundComponentComponent,
    }
]


@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class UserRoutingModule { }