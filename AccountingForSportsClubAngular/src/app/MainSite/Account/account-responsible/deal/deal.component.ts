import { Component, OnDestroy, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthActivateService } from 'src/app/Auth/services/auth-activate.service';
import { ResponsibleService } from 'src/app/MainSite/Entities/responsible/service/responsible.service';
import { Roles } from 'src/app/models/roles.enum';
import { Deal } from '../models/deal.model';
import { DealService } from '../services/deal.service';

@Component({
  selector: 'app-deal',
  templateUrl: './deal.component.html',
  styleUrls: ['./deal.component.css'],
  providers: [DealService, ResponsibleService]
})
export class DealComponent implements OnInit, OnDestroy {

  @ViewChild('readOnlyTemplate', { static: false }) readOnlyTemplate!: TemplateRef<any>;
  public deals: Array<Deal>;
  public dealKeys: Array<string>;
  public dealNames: Array<string>;
  private subscription: Subscription[];

  constructor(
    private dealService: DealService,
    private responsibleService: ResponsibleService,
    private router: Router,
  ) {

    this.deals = [];
    this.dealKeys = [];
    this.dealNames = [];
    this.subscription = [];
  }

  private loadDeals(): void {
    let subLoadDeals: Subscription = this.dealService.getDeals().subscribe({
      next: (data: Array<Deal>) => {
        this.dealNames = [];
        this.deals = data;
        for (let key in data[0]) {
          if (key == 'id' || key == 'subscriptionAmountWorkouts')
            continue;
          this.dealNames.push(key.charAt(0).toUpperCase() + key.slice(1));
        }
      },
      error: (err) => {
        if (err.status == '403') {
          alert("Don't have acceess");
        }
        else {
          throw new Error("Cann't get Deals")
        }
      }
    })

    this.subscription.push(subLoadDeals);
  }

  public delete(id: number): void {
    let deleteDealSubscription = this.dealService.deleteDeal(id).subscribe({
      next: () => { this.loadDeals() },
      error: (err) => {
        if (err.status = '403')
          alert("Don't have access")
      },
    })

    this.subscription.push(deleteDealSubscription);
  }

  public ngOnInit(): void {
    this.loadDeals();
  }

  public loadTemplate(deal: any): TemplateRef<any> {
    this.dealKeys = [];

    for (const key in deal) {
      if (key == 'id' || key == 'subscriptionAmountWorkouts') continue;
      this.dealKeys.push(deal[key]);
    }

    return this.readOnlyTemplate;
  }

  public redirectOnEdit(id: number) {
    let role: string = AuthActivateService.getSession()?.role ?? '';
    let email: string = AuthActivateService.getSession()?.email ?? '';

    if (role == "") {
      alert("Don't have access");
      return;
    }

    switch (role) {
      case Roles.Administrator:
        this.routeOnEditDeal(id);
        break;
      case Roles.Responsible:
        let subGetResponsibleIdByIdEmail: Subscription = this.responsibleService.getResponsibleIdByEmail(email.toLowerCase()).subscribe({
          next: (currentId: number) => {
            let subGetResponsibleIdByDealId: Subscription = this.dealService.getResponsibleIdByDealId(id).subscribe({
              next: (checkId: number) => { this.checkResemblanceIdWithCurrent(currentId, checkId, id) }
            })
            this.subscription.push(subGetResponsibleIdByDealId);
          },
          error: () => alert("Don't have access")
        });
        this.subscription.push(subGetResponsibleIdByIdEmail);
        break;
      default: alert("Don't have access");
    }
  }

  private checkResemblanceIdWithCurrent(currentId: number, checkId: number, id: number) {
    if (currentId == checkId) {
      this.routeOnEditDeal(id);
    }
    else {
      alert("Don't have access");
    }
  }

  private routeOnEditDeal(id: number): void {
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['account-responsible', { outlets: { 'account': ['update-deal', id] } }] } }]);
  }

  ngOnDestroy(): void {
    this.subscription.forEach((x) => { x.unsubscribe() });
  }
}
