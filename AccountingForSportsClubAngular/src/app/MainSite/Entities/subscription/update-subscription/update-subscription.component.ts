import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Serve } from '../../serve/model/serve.model';
import { ServeService } from '../../serve/services/serve.service';
import { SubscriptionModel } from '../models/subscription.model';
import { UpdateSubscription } from '../models/update-subscription.model';
import { SubscriptionService } from '../services/subscription.service';

@Component({
  selector: 'app-update-subscription',
  templateUrl: './update-subscription.component.html',
  styleUrls: ['./update-subscription.component.css'],
  providers:[SubscriptionService, ServeService]
})
export class UpdateSubscriptionComponent implements OnInit, OnDestroy {

  public editSubscriptionModelForm: FormGroup;
  public subscriptionModel: SubscriptionModel;
  public response: any;
  public allServes: Array<Serve>;
  private subscription: Subscription[];

  constructor(private subscriptionService: SubscriptionService,
    private router: Router,
    private activateRoute: ActivatedRoute,
    private serveService: ServeService) {

    this.editSubscriptionModelForm = new FormGroup({});
    this.subscriptionModel = new SubscriptionModel(Number.NaN, "", "", "", "");
    this.allServes = [];
    this.subscription = [];

    this.editSubscriptionModelForm = new FormGroup({
      id: new FormControl(0, [Validators.required]),
      name: new FormControl("", [Validators.required, Validators.minLength(3)]),
      price: new FormControl("", [Validators.required, Validators.pattern("^[0-9]*$")]),
      amountWorkouts: new FormControl("", [Validators.required, Validators.pattern("^[0-9]*$")]),
      serviceId: new FormControl(0, [Validators.required])
    });
  }

  public ngOnInit() {
    let id: number = this.activateRoute.snapshot.params['id'];
    if (id == 0) {
      this.redirectOnPageException();
    }

    let subGetSubscriptionModel: Subscription = this.subscriptionService.getSubscriptionModel(id).subscribe((data: SubscriptionModel) => {
      this.subscriptionModel = data;

      this.editSubscriptionModelForm.controls['id'].setValue(this.subscriptionModel.id);
      this.editSubscriptionModelForm.controls['name'].setValue(this.subscriptionModel.name);
      this.editSubscriptionModelForm.controls['price'].setValue(this.subscriptionModel.price);
      this.editSubscriptionModelForm.controls['amountWorkouts'].setValue(this.subscriptionModel.amountWorkouts);

      let subGetAllServes: Subscription = this.serveService.getServeces().subscribe({
        next: (data: Array<Serve>) => {
          this.allServes = data;
          let currentIdServe = this.allServes.filter(x => x.name == this.subscriptionModel.serviceName)[0].id;
          this.editSubscriptionModelForm.controls['serviceId'].setValue(currentIdServe);
        }
      })

      this.subscription.push(subGetAllServes);
    });

    this.subscription.push(subGetSubscriptionModel)
  }

  private redirectOnPageException() {
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['Exception'] } }]);
  }

  private redirectBack() {
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['subscription'] } }]);
  }

  public onSubmit() {
    if (this.editSubscriptionModelForm.valid) {
      let obg = this.editSubscriptionModelForm.value;
      let updateSubscriptionModel: UpdateSubscription = 
            new UpdateSubscription(Number(obg.id), obg.name, Number(obg.amountWorkouts), Number(obg.price), Number(obg.serviceId));
      let subUpdateSubscriptionModel: Subscription = this.subscriptionService.updateSubscriptionModel(updateSubscriptionModel).subscribe(x => {
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
