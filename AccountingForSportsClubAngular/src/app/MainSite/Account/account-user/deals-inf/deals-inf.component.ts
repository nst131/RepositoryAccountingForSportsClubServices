import { Component, OnDestroy, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { DealInf } from '../models/deal-inf.model';
import { AccountUserService } from '../services/account-user.service';

@Component({
  selector: 'app-deals-inf',
  templateUrl: './deals-inf.component.html',
  styleUrls: ['./deals-inf.component.css'],
  providers: [AccountUserService]
})
export class DealsInfComponent implements OnInit, OnDestroy {

  @ViewChild('readOnlyTemplate', { static: false }) readOnlyTemplate!: TemplateRef<any>;
  public dealInfs: Array<DealInf>;
  public dealInfsName: Array<string>;
  public dealInfKeys: Array<string>;
  private subscription: Array<Subscription>;

  constructor(
    private accountUserService: AccountUserService,
    private activateRoute: ActivatedRoute) {

    this.dealInfs = new Array<DealInf>();
    this.dealInfsName = [];
    this.dealInfKeys = [];
    this.subscription = [];
  }

  public ngOnInit(): void {
    this.loadDealInfs();
  }

  private loadDealInfs(): void {
    let clientId: number = this.activateRoute.snapshot.params['id'];

    let subLoadDealInfs: Subscription = this.accountUserService.getUserDealsInf(clientId).subscribe({
      next: (data: Array<DealInf>) => {
        this.dealInfsName = [];
        this.dealInfs = data;
        for (let key in data[0]) {
          this.dealInfsName.push(key.charAt(0).toUpperCase() + key.slice(1));
        }
      }
    })
    this.subscription.push(subLoadDealInfs);
  }

  public loadTemplate(dealInf: any): TemplateRef<any> {
    this.dealInfKeys = [];
    for (const key in dealInf) {
      this.dealInfKeys.push(dealInf[key]);
    }
    return this.readOnlyTemplate;
  }

  ngOnDestroy(): void {
    this.subscription.forEach((x) => { x.unsubscribe() });
  }
}
