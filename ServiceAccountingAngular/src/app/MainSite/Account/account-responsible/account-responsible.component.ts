import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-account-responsible',
  templateUrl: './account-responsible.component.html',
  styleUrls: ['./account-responsible.component.css']
})
export class AccountResponsibleComponent {

  constructor(private router: Router) { }

  public redirectOnCreateVisit() {
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['account-responsible', { outlets: { 'account': ['create-visit'] } }] } }]);
  }

  public redirectOnCreateDeal() {
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['account-responsible', { outlets: { 'account': ['create-deal'] } }] } }]);
  }

  public redirectOnShowVisits() {
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['account-responsible', { outlets: { 'account': ['visit'] } }] } }]);
  }

  public redirectOnShowDeals() {
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['account-responsible', { outlets: { 'account': ['deal'] } }] } }]);
  }

}
