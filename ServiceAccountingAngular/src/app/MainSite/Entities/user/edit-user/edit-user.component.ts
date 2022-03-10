import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserUpdateModel } from '../models/user-update.model';
import { User } from '../models/user.model';
import { UserService } from '../services/user.service';
import { Subscription } from 'rxjs';
import { LoadTypeOfSexService } from 'src/app/MainSite/services/load-type-of-sex';
import { TypeOfSexModel } from 'src/app/MainSite/models/type-of-sex.model';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css'],
  providers: [UserService, LoadTypeOfSexService]
})

export class EditUserComponent implements OnInit, OnDestroy {
  public id: number;
  public editUserForm: FormGroup;
  public user: User;
  public viewsTypeOfSex: Array<TypeOfSexModel>;
  public currentTypeOfSex: number;
  public response: any;
  private subscription: Subscription[];

  constructor(private userService: UserService,
    private loadTypeOfSex: LoadTypeOfSexService,
    private router: Router,
    private activateRoute: ActivatedRoute) {

    this.id = 0;
    this.editUserForm = new FormGroup({});
    this.user = new User(Number.NaN, "", "", "", "", "");
    this.viewsTypeOfSex = [];
    this.currentTypeOfSex = 1;
    this.subscription = [];

    this.editUserForm = new FormGroup({
      serName: new FormControl("", [Validators.required, Validators.minLength(3)]),
      telephone: new FormControl("", [Validators.required, Validators.pattern('[0-9]{2} [0-9]{3}-[0-9]{2}-[0-9]{2}')]),
      typeSexId: new FormControl(0, [Validators.required]),
    });
  }

  public ngOnInit() {
    this.id = this.activateRoute.snapshot.params['id'];
    if (this.id == 0) {
      this.redirectOnPageException();
    }
    this.viewsTypeOfSex = this.loadTypeOfSex.GetViewsTypeOfSex();
    let subGetUser: Subscription = this.userService.getUser(this.id).subscribe((data: User) => {
      this.user = data;
      this.currentTypeOfSex = this.viewsTypeOfSex.filter(x => x.name == this.user.typeSex)[0].value;

      this.editUserForm.controls['serName'].setValue(this.user.serName);
      this.editUserForm.controls['telephone'].setValue(this.user.telephone);
      this.editUserForm.controls['typeSexId'].setValue(this.currentTypeOfSex);
    });

    this.subscription.push(subGetUser)
  }

  private redirectOnPageException() {
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['Exception'] } }]);
  }

  private redirectBack() {
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['user'] } }]);
  }

  public onSubmit() {
    if (this.editUserForm.valid) {
      let obg = this.editUserForm.value;
      let updateUser = new UserUpdateModel(Number(this.id), this.user.name, obg.serName, obg.telephone, obg.typeSexId);
      let subUpdateUser: Subscription = this.userService.updateUser(updateUser).subscribe(x => {
        if (x.error) {
          this.redirectOnPageException();
        }
        else {
          this.response = x.response;
          this.editUserForm.reset;
          this.redirectBack();
        }
      });
      this.subscription.push(subUpdateUser);
    }
  }

  ngOnDestroy(): void {
    this.subscription.forEach(x => x.unsubscribe());
  }
}
