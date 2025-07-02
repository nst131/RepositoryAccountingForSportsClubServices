import { Component, OnDestroy, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthActivateService } from 'src/app/Auth/services/auth-activate.service';
import { Roles } from 'src/app/models/roles.enum';
import { SubscriptionModel } from './models/subscription.model';
import { SubscriptionService } from './services/subscription.service';

@Component({
  selector: 'app-subscription',
  templateUrl: './subscription.component.html',
  styleUrls: ['./subscription.component.css'],
  providers:[SubscriptionService]
})
export class SubscriptionComponent implements OnInit, OnDestroy {

  @ViewChild('readOnlyTemplate', { static: false }) readOnlyTemplate!: TemplateRef<any>;
  public subscriptionModels: Array<SubscriptionModel>;
  public subscriptionModelsName: Array<string>;
  public subscriptionModel: SubscriptionModel;
  private subscription: Subscription[];

  constructor(private subscriptionService: SubscriptionService, private router: Router) {
    this.subscriptionModels = new Array<SubscriptionModel>();
    this.subscriptionModelsName = [];
    this.subscriptionModel = new SubscriptionModel(Number.NaN,"","","","");
    this.subscription = [];
  }

  private loadSubscriptionModels(): void {
    let subLoadSubscriptionModels: Subscription = this.subscriptionService.getSubscriptionModelces().subscribe({
      next: (data: Array<SubscriptionModel>) => {
        this.subscriptionModelsName = [];
        this.subscriptionModels = data;
        for (let key in data[0]) {
          if (key == 'id') continue;

          this.subscriptionModelsName.push(key.charAt(0).toUpperCase() + key.slice(1));
        }
      },
      error: (err) => {
        if (err.status == '403') {
          alert("Don't have acceess");
        }
        else {
          throw new Error("Cann't get SubscriptionModels")
        }
      }
    })

    this.subscription.push(subLoadSubscriptionModels);
  }

  public deleteSubscriptionModel(id: number): void {
    let deleteSubscriptionModelSubscription = this.subscriptionService.deleteSubscriptionModel(id).subscribe({
      next: () => { this.loadSubscriptionModels() },
      error: (err) => {
        if (err.status = '403')
          alert("Don't have access")
      },
    })

    this.subscription.push(deleteSubscriptionModelSubscription);
  }

  public ngOnInit(): void {
    this.loadSubscriptionModels();
  }

  public loadTemplate(subscriptionModel: SubscriptionModel): TemplateRef<any> {
    this.subscriptionModel = subscriptionModel;

    return this.readOnlyTemplate;
  }

  public redirectOnEditSubscriptionModel(id: number) {
    let role: string = AuthActivateService.getSession()?.role ?? "";
    if (role == "") {
      alert("Don't have access");
      return;
    }

    switch (role) {
      case Roles.Administrator:
        this.routeOnEditSubscriptionModel(id);
        break;
      default: alert("Don't have access");
    }
  }

  private routeOnEditSubscriptionModel(id: number): void {
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['subscription', 'edit-subscription', id] } }]);
  }

  ngOnDestroy(): void {
    this.subscription.forEach((x) => { x.unsubscribe() });
  }
  
}
