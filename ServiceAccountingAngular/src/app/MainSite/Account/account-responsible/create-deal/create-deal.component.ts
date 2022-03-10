import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { ClubCard } from 'src/app/MainSite/Entities/club-card/models/club-card.model';
import { ClubCardService } from 'src/app/MainSite/Entities/club-card/services/club-card.service';
import { SubscriptionModel } from 'src/app/MainSite/Entities/subscription/models/subscription.model';
import { SubscriptionService } from 'src/app/MainSite/Entities/subscription/services/subscription.service';
import { User } from 'src/app/MainSite/Entities/user/models/user.model';
import { UserService } from 'src/app/MainSite/Entities/user/services/user.service';
import { ResponsibleService } from 'src/app/MainSite/Entities/responsible/service/responsible.service';
import { DealService } from '../services/deal.service';
import { Router } from '@angular/router';
import { RoutesService } from 'src/app/MainSite/services/routes.servic';
import { AuthActivateService } from 'src/app/Auth/services/auth-activate.service';
import { CreateDeal } from '../models/create-deal.model';

@Component({
  selector: 'app-create-deal',
  templateUrl: './create-deal.component.html',
  styleUrls: ['./create-deal.component.css'],
  providers: [SubscriptionService, ClubCardService, UserService, ResponsibleService, DealService]
})
export class CreateDealComponent implements OnInit, OnDestroy {

  public editDealForm: FormGroup;
  public response: any;
  public error: boolean;
  public messageError: string;
  private subscription: Subscription[];

  public allSubscriptions: Array<SubscriptionModel>;
  public allClients: Array<User>;
  public allClubCards: Array<ClubCard>

  constructor(
    private subscriptionService: SubscriptionService,
    private clientService: UserService,
    private clubCardService: ClubCardService,
    private responsibleService: ResponsibleService,
    private dealService: DealService,
    private router: Router,
    private routesService: RoutesService) {

    this.editDealForm = new FormGroup({});
    this.error = false;
    this.messageError = '';
    this.subscription = [];

    this.allSubscriptions = [];
    this.allClients = [];
    this.allClubCards = []

    this.editDealForm = new FormGroup({
      purchaseDate: new FormControl(new Date(), []),
      subscriptionId: new FormControl("", [Validators.required]),
      clientId: new FormControl("", [Validators.required]),
      clubCardId: new FormControl("", [Validators.required]),
      responsibleId: new FormControl("", [Validators.required])
    });
  }

  public ngOnInit() {

    let subGetAllSubscriptions: Subscription = this.subscriptionService.getSubscriptionModelces().subscribe({
      next: (data: Array<SubscriptionModel>) => {
        this.allSubscriptions.push(new SubscriptionModel(0, 'Nothing', '', '', ''));
        data.forEach(x => this.allSubscriptions.push(x));
        this.editDealForm.controls['subscriptionId'].setValue(this.allSubscriptions[0].id);
      }
    })
    this.subscription.push(subGetAllSubscriptions);

    let subGetAllClients: Subscription = this.clientService.getUsers().subscribe({
      next: (data: Array<User>) => {
        this.allClients = data;
        this.editDealForm.controls['clientId'].setValue(this.allClients[0].id);
      }
    })
    this.subscription.push(subGetAllClients);

    let subGetAllClubCards: Subscription = this.clubCardService.getClubCardces().subscribe({
      next: (data: Array<ClubCard>) => {
        this.allClubCards.push(new ClubCard(0, 'Nothing', '', '', ''));
        data.forEach(x => this.allClubCards.push(x));
        this.editDealForm.controls['clubCardId'].setValue(this.allClubCards[0].id);
      }
    })
    this.subscription.push(subGetAllClubCards);

    let subGetResponsibleId: Subscription = this.responsibleService.getResponsibleIdByEmail(AuthActivateService.getSession()?.email ?? '').subscribe({
      next: (data: number) => {
        this.editDealForm.controls['responsibleId'].setValue(data)
      }
    })
    this.subscription.push(subGetResponsibleId);

  }

  private redirectOnPageException() {
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['Exception'] } }]);
  }

  private redirectBack() {
    this.routesService.redirectOnPageAccount();
  }

  public onSubmit() {
    if (this.editDealForm.valid) {
      let obg = this.editDealForm.value;

      if (obg.subscriptionId == 0) {
        obg.subscriptionId = null;
      }
      if (obg.clubCardId == 0) {
        obg.clubCardId = null;
      }

      let createDeal: CreateDeal = new CreateDeal(Number(obg.clientId), Number(obg.responsibleId), obg.purchaseDate, obg.subscriptionId, obg.clubCardId);
      let subCreateDeal: Subscription = this.dealService.createDeal(createDeal).subscribe({
        
        next:(data: any) => {
          this.error = false;
          this.response = data.response;
          this.editDealForm.reset();
          this.redirectBack();
        },

        error: (err) => {
          let errors = err.error.errors;

          if (errors) {
              for (var i in errors) {
                  if (errors.hasOwnProperty(i) && typeof (i) !== 'function') {
                      this.messageError = errors[i][0].split('Path')[0];
                      this.error = true;
                      break;
                  }
              }
          }
          else{
            this.error = false;
            this.redirectOnPageException();
          }
        }

      });
      this.subscription.push(subCreateDeal);
    }
    
  }

  ngOnDestroy(): void {
    this.subscription.forEach(x => x.unsubscribe());
  }

}
