import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-account-admin',
  templateUrl: './account-admin.component.html',
  styleUrls: ['./account-admin.component.css']
})
export class AccountAdminComponent {

  constructor(private router: Router) { }

  public redirectOnRegistrationUsersAsAdmin() {
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['account-admin', { outlets: { 'account': ['registration-as-admin'] } }] } }]);
  }

  public redirectOnCreatePlace() {
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['account-admin', { outlets: { 'account': ['create-place'] } }] } }]);
  }

  public redirectOnCreateSubscription() {
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['account-admin', { outlets: { 'account': ['create-subscription'] } }] } }]);
  }

  public redirectOnCreateServe() {
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['account-admin', { outlets: { 'account': ['create-serve'] } }] } }]);
  }

  public redirectOnCreateClubCard() {
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['account-admin', { outlets: { 'account': ['create-club-card'] } }] } }]);
  }
}
