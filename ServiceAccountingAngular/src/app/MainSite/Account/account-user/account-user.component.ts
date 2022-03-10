import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthActivateService } from 'src/app/Auth/services/auth-activate.service';
import { UserService } from '../../Entities/user/services/user.service';
import { ClientCardInf } from './models/client-card-Inf.model';
import { ClientInf } from './models/client-Inf.model';
import { MainInformationUser } from './models/main-information-user.model';
import { AccountUserService } from './services/account-user.service';

@Component({
  selector: 'app-account-user',
  templateUrl: './account-user.component.html',
  styleUrls: ['./account-user.component.css'],
  providers: [AccountUserService, UserService]
})
export class AccountUserComponent implements OnInit, OnDestroy {
  public clientInf: ClientInf;
  public clientCardInf: ClientCardInf;
  public clientId!: number;
  private subscription: Array<Subscription> = [];

  constructor(
    private router: Router,
    private accountUserService: AccountUserService,
    private userService: UserService) {
      this.clientInf = new ClientInf("","","","");
      this.clientCardInf = new ClientCardInf("","","","");
    }

  ngOnInit(): void {
    let subGetUserId = this.userService.getUserIdByEmail(AuthActivateService.getSession()?.email ?? '').subscribe({
      next:(clientId: number) => {
        let subMainInf = this.accountUserService.getMainInformationUser(clientId).subscribe({
          next:(data: MainInformationUser) => {
            this.clientId = clientId;
            this.clientInf = data.clientInf;
            this.clientCardInf = data.clientCardInf;
          }
        })
        this.subscription.push(subMainInf);
      }
    })

    this.subscription.push(subGetUserId);
  }

  public redirectOnShowVisits(){
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['account-user', { outlets: { 'account': ['visitsInf', this.clientId] } }] } }]);
  }

  public redirectOnShowDeals(){
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['account-user', { outlets: { 'account': ['dealsInf', this.clientId] } }] } }]);
  }

  public redirectOnShowSubscriptions(){
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['account-user', { outlets: { 'account': ['subscriptionsInf', this.clientId] } }] } }]);
  }

  public redirectOnShowTrainings(){
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['account-user', { outlets: { 'account': ['trainingsInf', this.clientId] } }] } }]);
  }

  ngOnDestroy(): void {
    this.subscription.forEach(x => x.unsubscribe());
  }
}
