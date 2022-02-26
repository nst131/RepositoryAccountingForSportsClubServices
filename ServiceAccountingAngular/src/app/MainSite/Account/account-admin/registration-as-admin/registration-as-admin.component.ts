import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { AuthActivateService } from 'src/app/Auth/services/auth-activate.service';
import { loadRolesService } from 'src/app/Auth/services/load-roles.service';
import { emailValidator } from 'src/app/Auth/validators/email.validators';
import { RegistrationAsAdminModel } from './models/registration-as-admin.model';
import { RegistrationAsAdminService } from './services/registration-as-admin.service';

@Component({
  selector: 'app-registration-as-admin',
  templateUrl: './registration-as-admin.component.html',
  styleUrls: ['./registration-as-admin.component.css'],
  providers: [loadRolesService, RegistrationAsAdminService, AuthActivateService]
})
export class RegistrationAsAdminComponent implements OnInit, OnDestroy {
  public registrationAsAdmin: FormGroup;
  public roles: string[];
  public response: any;
  public messageError: string;
  public showError: boolean;
  private subscription: Subscription;

  constructor(
    private registrationAsAdminService: RegistrationAsAdminService,
    private rolesService: loadRolesService,
    private authActivateService: AuthActivateService) {
    this.registrationAsAdmin = new FormGroup({});
    this.roles = [];
    this.messageError = "";
    this.showError = false;
    this.subscription = new Subscription();
  }

  ngOnInit(): void {
    this.roles = this.rolesService.getRolesWithoutAdmin();
    this.registrationAsAdmin = new FormGroup({
      email: new FormControl(null, [Validators.required, Validators.minLength(3), emailValidator]),
      name: new FormControl(null, [Validators.required, Validators.minLength(3)]),
      password: new FormControl(null, [Validators.required]),
      role: new FormControl("User", [Validators.required])
    });
  };

  onSubmit() {
    if (this.registrationAsAdmin.valid) {
      let obj = this.registrationAsAdmin.value;
      console.log(obj);
      this.subscription = this.registrationAsAdminService
        .tryRegistrationAsAdmin(new RegistrationAsAdminModel(obj.email, obj.name, obj.password, obj.role)).subscribe(x => {
          if (x.error) {
            this.messageError = x.messageError;
            this.showError = true;
            this.registrationAsAdmin.reset()
          }
          else {
            x.subscribe((data: any) => { this.response = data.response });
            this.showError = false;
            this.registrationAsAdmin.reset();
            this.authActivateService.redirectOnMainSite();
          }
        });
    }
  };

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

}
