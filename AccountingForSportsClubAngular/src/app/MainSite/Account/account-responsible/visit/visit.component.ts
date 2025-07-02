import { Component, OnDestroy, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthActivateService } from 'src/app/Auth/services/auth-activate.service';
import { ResponsibleService } from 'src/app/MainSite/Entities/responsible/service/responsible.service';
import { Roles } from 'src/app/models/roles.enum';
import { Visit } from '../models/visit.model';
import { VisitService } from '../services/visit.service';

@Component({
  selector: 'app-visit',
  templateUrl: './visit.component.html',
  styleUrls: ['./visit.component.css'],
  providers: [VisitService, ResponsibleService]
})
export class VisitComponent implements OnInit, OnDestroy {

  @ViewChild('readOnlyTemplate', { static: false }) readOnlyTemplate!: TemplateRef<any>;
  public visits: Array<Visit>;
  public visitKeys: Array<string>;
  public visitNames: Array<string>;
  private subscription: Subscription[];

  constructor(
    private visitService: VisitService,
    private router: Router,
    private responsibleService: ResponsibleService) {

    this.visits = new Array<Visit>();
    this.visitKeys = [];
    this.visitNames = [];
    this.subscription = [];
  }

  private loadVisits(): void {
    let subLoadVisits: Subscription = this.visitService.getVisits().subscribe({
      next: (data: Array<Visit>) => {
        this.visitNames = [];
        this.visits = data;
        for (let key in data[0]) {
          if (key == 'id') continue;

          this.visitNames.push(key.charAt(0).toUpperCase() + key.slice(1));
        }
      },
      error: (err) => {
        if (err.status == '403') {
          alert("Don't have acceess");
        }
        else {
          throw new Error("Cann't get Visits")
        }
      }
    })

    this.subscription.push(subLoadVisits);
  }

  public deleteVisit(id: number): void {
    let deleteVisitSubscription = this.visitService.deleteVisit(id).subscribe({
      next: () => { this.loadVisits() },
      error: (err) => {
        if (err.status = '403')
          alert("Don't have access")
      },
    })

    this.subscription.push(deleteVisitSubscription);
  }

  public ngOnInit(): void {
    this.loadVisits();
  }

  public loadTemplate(visit: any): TemplateRef<any> {
    this.visitKeys = [];

    for (const key in visit) {
      if (key == 'id') continue;
      this.visitKeys.push(visit[key]);
    }

    return this.readOnlyTemplate;
  }

  public redirectOnEditVisit(id: number) {
    let role: string = AuthActivateService.getSession()?.role ?? "";
    if (role == "") {
      alert("Don't have access");
      return;
    }

    switch (role) {
      case Roles.Administrator:
        this.routeOnEditVisit(id);
        break;
      case Roles.Responsible:
        this.routeOnEditVisit(id);
        break;
      default: alert("Don't have access");
    }
  }

  private routeOnEditVisit(id: number): void {
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['account-responsible', { outlets: { 'account': ['update-visit', id] } }] } }]);
  }

  ngOnDestroy(): void {
    this.subscription.forEach((x) => { x.unsubscribe() });
  }

}
