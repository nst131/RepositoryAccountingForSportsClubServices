import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { emailValidator } from '../validators/email.validators';
import { RegistrationUserService } from '../services/registration-user.service';
import { RegistrationUserModel } from '../models/registrationUser.model';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css'],
  providers: [RegistrationUserService]
})
export class RegistrationComponent implements OnInit {

  public registrationForm: FormGroup = new FormGroup({});
  public response: any;

  public messageError: string = "";
  public showError: boolean = false;

  constructor( private registrationUserService: RegistrationUserService) {  }

  ngOnInit(): void {
    this.registrationForm = new FormGroup({
      email: new FormControl(null, [Validators.required, Validators.minLength(3), emailValidator]),
      name: new FormControl(null, [Validators.required, Validators.minLength(3)]),
      password: new FormControl(null, [Validators.required])
    });
  };

  onSubmit() {
    if (this.registrationForm.valid) {
      let obj = this.registrationForm.value;
      this.registrationUserService.TryRegistrationUser(new RegistrationUserModel(obj.email, obj.name, obj.password)).subscribe(x => {
        if (x.error) {
          this.messageError = x.messageError;
          this.showError = true;
          this.registrationForm.reset()
        }
        else {
          this.response = x.response;
          this.showError = false;
          this.registrationForm.reset();
        }
      });
    }
  };

}
