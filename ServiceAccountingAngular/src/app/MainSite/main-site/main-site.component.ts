import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthActivateService } from 'src/app/Auth/services/auth-activate.service';
import { Roles } from 'src/app/models/roles.enum';
import { RoutesService } from '../services/routes.servic';

@Component({
  selector: 'app-main-site',
  templateUrl: './main-site.component.html',
  styleUrls: ['./main-site.component.css'],
})
export class MainSiteComponent {

  constructor(
    private router: Router,
    private authActivateService: AuthActivateService,
    private routesService: RoutesService) { }

  public logout(): void {
    this.authActivateService.logoutService();
    this.authActivateService.redirectOnAuth();
  }

  public async redirectOnPageAccount() {
    this.routesService.redirectOnPageAccount();
  }

  public async redirectOnPageUsers() {
    await this.redirectOnPage(['/main-site', { outlets: { 'main-site': ['user'] } }])
  }

  public async redirectOnPageTrainers() {
    await this.redirectOnPage(['/main-site', { outlets: { 'main-site': ['trainer'] } }])
  }

  public async redirectOnPageResponsibles() {
    await this.redirectOnPage(['/main-site', { outlets: { 'main-site': ['responsible'] } }])
  }

  public async redirectOnPageServices() {
    await this.redirectOnPage(['/main-site', { outlets: { 'main-site': ['service'] } }])
  }

  public async redirectOnPagePlaces() {
    await this.redirectOnPage(['/main-site', { outlets: { 'main-site': ['place'] } }])
  }

  public async redirectOnPageClubCard() {
    await this.redirectOnPage(['/main-site', { outlets: { 'main-site': ['club-card'] } }])
  }

  public async redirectOnPageSubscription() {
    await this.redirectOnPage(['/main-site', { outlets: { 'main-site': ['subscription'] } }])
  }

  private async redirectOnPage(path: any[]) {
    if (!await this.router.navigate(path)) {
      if (this.authActivateService.SessionIsValid()) {
        window.location.reload();
      }
    }
  }
}
