import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthActivateService } from 'src/app/Auth/services/auth-activate.service';

@Component({
  selector: 'app-main-site',
  templateUrl: './main-site.component.html',
  styleUrls: ['./main-site.component.css'],
})
export class MainSiteComponent {

  constructor(private router: Router, private authActivateService: AuthActivateService) { }

  public async redirectOnPageUser() {
    if (!await this.router.navigate(['/main-site', { outlets: { 'main-site': ['user'] } }])) {
      if (this.authActivateService.SessionIsValid()) {
        window.location.reload();
      }
    }
  }

  public async redirectOnPageTrainers() {
    if (!await this.router.navigate(['/main-site', { outlets: { 'main-site': ['trainer'] } }])) {
      if (this.authActivateService.SessionIsValid()) {
        window.location.reload();
      }
    }
  }

  public async redirectOnPageResponsibles() {
    if (!await this.router.navigate(['/main-site', { outlets: { 'main-site': ['responsible'] } }])) {
      if (this.authActivateService.SessionIsValid()) {
        window.location.reload();
      }
    }
  }
  
}
