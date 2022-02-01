import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { emailValidator } from '../validators/email.validators';
import { loadRolesService } from '../services/load-roles.service';
import { LoginModel } from '../models/login.model';
import { loginService } from '../services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [loadRolesService, loginService]
})
export class LoginComponent implements OnInit {

  public loginForm: FormGroup = new FormGroup({});
  public roles: string[] = [];
  public token: string = "";

  public messageError: string = "";
  public error: boolean = false;

  constructor(private rolesService: loadRolesService, private login: loginService) {
    this.roles = rolesService.getRoles();
  }

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      email: new FormControl(null, [Validators.required, Validators.minLength(3), emailValidator]),
      password: new FormControl(null, [Validators.required]),
      role: new FormControl("User", [Validators.required])
    });
  };

  onSubmit() {
    if (this.loginForm.valid) {
      let obj = this.loginForm.value;
      this.login.TryLogin(new LoginModel(obj.email, obj.password, obj.role)).subscribe(x => {
        if (x.error) {
          this.messageError = x.messageError;
          this.error = true;
          this.loginForm.reset({
            role: "User"
          })
        }
        else {
          this.token = x.token;
          this.error = false;
          this.loginForm.reset();
        }
      });
    }
  };

}
