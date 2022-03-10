import { Component, OnDestroy, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { SubscriptionInf } from '../models/subscription-inf.model';
import { AccountUserService } from '../services/account-user.service';

@Component({
  selector: 'app-subscriptions-inf',
  templateUrl: './subscriptions-inf.component.html',
  styleUrls: ['./subscriptions-inf.component.css'],
  providers: [AccountUserService]
})
export class SubscriptionsInfComponent implements OnInit, OnDestroy {

  @ViewChild('readOnlyTemplate', { static: false }) readOnlyTemplate!: TemplateRef<any>;
  public subscriptionsInf: Array<SubscriptionInf>;
  public subscriptionsInfName: Array<string>;
  public subscriptionInfKeys: Array<string>;
  private subscription: Array<Subscription>;

  constructor(
    private accountUserService: AccountUserService,
    private activateRoute: ActivatedRoute) {

    this.subscriptionsInf = new Array<SubscriptionInf>();
    this.subscriptionsInfName = [];
    this.subscriptionInfKeys = [];
    this.subscription = [];
  }

  public ngOnInit(): void {
    this.loadSubscriptionsInf();
  }

  private loadSubscriptionsInf(): void {
    let clientId: number = this.activateRoute.snapshot.params['id'];

    let subLoadSubscriptionsInf: Subscription = this.accountUserService.getUserSubscriprionsInf(clientId).subscribe({
      next: (data: Array<SubscriptionInf>) => {
        this.subscriptionsInfName = [];
        this.subscriptionsInf = data;
        for (let key in data[0]) {
          this.subscriptionsInfName.push(key.charAt(0).toUpperCase() + key.slice(1));
        }
      }
    })
    this.subscription.push(subLoadSubscriptionsInf);
  }

  public loadTemplate(subInf: any): TemplateRef<any> {
    this.subscriptionInfKeys = [];
    for (const key in subInf) {
      this.subscriptionInfKeys.push(subInf[key]);
    }
    return this.readOnlyTemplate;
  }

  ngOnDestroy(): void {
    this.subscription.forEach((x) => { x.unsubscribe() });
  }
}
