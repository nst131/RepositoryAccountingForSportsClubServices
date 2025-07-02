import { Component, OnDestroy, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { VisitInf } from '../models/visit-inf.model';
import { AccountUserService } from '../services/account-user.service';

@Component({
  selector: 'app-visits-inf',
  templateUrl: './visits-inf.component.html',
  styleUrls: ['./visits-inf.component.css'],
  providers:[AccountUserService]
})
export class VisitsInfComponent implements OnInit, OnDestroy {

  @ViewChild('readOnlyTemplate', { static: false }) readOnlyTemplate!: TemplateRef<any>;
  public visitInfs: Array<VisitInf>;
  public visitInfsName: Array<string>;
  public visitInfKeys: Array<string>;
  private subscription: Array<Subscription>;

  constructor(
    private accountUserService: AccountUserService,
    private activateRoute: ActivatedRoute) {

    this.visitInfs = new Array<VisitInf>();
    this.visitInfsName = [];
    this.visitInfKeys = [];
    this.subscription = [];
  }

  public ngOnInit(): void {
    this.loadVisitInfs();
  }

  private loadVisitInfs(): void {
    let clientId: number = this.activateRoute.snapshot.params['id'];

    let subLoadVisitInfs: Subscription = this.accountUserService.getUserVisitsInf(clientId).subscribe({
      next: (data: Array<VisitInf>) => {
        this.visitInfsName = [];
        this.visitInfs = data;
        for (let key in data[0]) {
          this.visitInfsName.push(key.charAt(0).toUpperCase() + key.slice(1));
        }
      }
    })
    this.subscription.push(subLoadVisitInfs);
  }

  public loadTemplate(visitInf: any): TemplateRef<any> {
    this.visitInfKeys = [];
    for (const key in visitInf) {
      this.visitInfKeys.push(visitInf[key]);
    }
    return this.readOnlyTemplate;
  }

  ngOnDestroy(): void {
    this.subscription.forEach((x) => { x.unsubscribe() });
  }
}
