import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthRoutingModule } from './auth-routing.module';
import { LoginComponent } from '../login/login.component';
import { RegistrationComponent } from '../registration/registration.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { MatButtonModule } from '@angular/material/button';
import { AuthComponent } from '../auth/auth.component';

@NgModule({
  declarations: [
    AuthComponent,
    LoginComponent,
    RegistrationComponent ,
  ],
  imports: [
    AuthRoutingModule,

    CommonModule,
    FormsModule,
    ReactiveFormsModule,

    HttpClientModule,

    MatButtonModule
  ]
})
export class AuthModule { }
