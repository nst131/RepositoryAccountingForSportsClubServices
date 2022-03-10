import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Serve } from 'src/app/MainSite/Entities/serve/model/serve.model';
import { ServeService } from 'src/app/MainSite/Entities/serve/services/serve.service';
import { SubscriptionModel } from 'src/app/MainSite/Entities/subscription/models/subscription.model';
import { SubscriptionService } from 'src/app/MainSite/Entities/subscription/services/subscription.service';
import { RoutesService } from 'src/app/MainSite/services/routes.servic';
import { CreateSubscription } from './models/create-subscription.model';

@Component({
  selector: 'app-create-subscription',
  templateUrl: './create-subscription.component.html',
  styleUrls: ['./create-subscription.component.css'],
  providers: [SubscriptionService, ServeService]
})
export class CreateSubscriptionComponent implements OnInit, OnDestroy {

  public editSubscriptionModelForm: FormGroup;
  public subscriptionModel: SubscriptionModel;
  public allServes: Array<Serve>
  public response: any;
  private subscription: Subscription[];

  constructor(private subscriptionService: SubscriptionService,
    private router: Router,
    private serveService: ServeService,
    private routesService: RoutesService) {

    this.editSubscriptionModelForm = new FormGroup({});
    this.subscriptionModel = new SubscriptionModel(Number.NaN, "", "", "", "");
    this.allServes = [];
    this.subscription = [];

    this.editSubscriptionModelForm = new FormGroup({
      name: new FormControl("", [Validators.required, Validators.minLength(3)]),
      price: new FormControl("", [Validators.required, Validators.pattern("^[0-9]*$")]),
      amountWorkouts: new FormControl("", [Validators.required, Validators.pattern('^[0-9]*$')]),
      serviceId: new FormControl(0, [Validators.required])
    });
  }

  public ngOnInit() {

    let subGetAllPlaces : Subscription = this.serveService.getServeces().subscribe({
      next: (data: Array<Serve>) => {
        this.allServes = data;
        this.editSubscriptionModelForm.controls['serviceId'].setValue(this.allServes[0].id);
      }
    })

    this.subscription.push(subGetAllPlaces)
  }

  private redirectOnPageException() {
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['Exception'] } }]);
  }

  private redirectBack() {
    this.routesService.redirectOnPageAccount();
  }

  public onSubmit() {
    if (this.editSubscriptionModelForm.valid) {
      let obg = this.editSubscriptionModelForm.value;
      let createSubscriptionModel: CreateSubscription = 
            new CreateSubscription(obg.name, Number(obg.amountWorkouts), Number(obg.price), Number(obg.serviceId));
      let subUpdateSubscriptionModel: Subscription = this.subscriptionService.createSubscriptionModel(createSubscriptionModel).subscribe(x => {
        if (x.error) {
          this.redirectOnPageException();
        }
        else {
          this.response = x.response;
          this.editSubscriptionModelForm.reset;
          this.redirectBack();
        }
      });
      this.subscription.push(subUpdateSubscriptionModel);
    }
  }

  ngOnDestroy(): void {
    this.subscription.forEach(x => x.unsubscribe());
  }

}
