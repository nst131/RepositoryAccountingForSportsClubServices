import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthActivateService } from 'src/app/Auth/services/auth-activate.service';
import { ClubCard } from 'src/app/MainSite/Entities/club-card/models/club-card.model';
import { ClubCardService } from 'src/app/MainSite/Entities/club-card/services/club-card.service';
import { ResponsibleService } from 'src/app/MainSite/Entities/responsible/service/responsible.service';
import { SubscriptionModel } from 'src/app/MainSite/Entities/subscription/models/subscription.model';
import { SubscriptionService } from 'src/app/MainSite/Entities/subscription/services/subscription.service';
import { User } from 'src/app/MainSite/Entities/user/models/user.model';
import { UserService } from 'src/app/MainSite/Entities/user/services/user.service';
import { RoutesService } from 'src/app/MainSite/services/routes.servic';
import { Deal } from '../models/deal.model';
import { UpdateDeal } from '../models/update-deal.model';
import { DealService } from '../services/deal.service';

@Component({
  selector: 'app-update-deal',
  templateUrl: './update-deal.component.html',
  styleUrls: ['./update-deal.component.css'],
  providers: [SubscriptionService, ClubCardService, UserService, ResponsibleService, DealService]
})
export class UpdateDealComponent implements OnInit, OnDestroy {

  public editDealForm: FormGroup;
  public response: any;
  public error: boolean;
  public messageError: string;
  private subscription: Subscription[];

  public deal: Deal;
  public allSubscriptions: Array<SubscriptionModel>;
  public allClubCards: Array<ClubCard>
  public allClients: Array<User>;

  constructor(
    private dealService: DealService,
    private subscriptionService: SubscriptionService,
    private clubCardService: ClubCardService,
    private userSertvice: UserService,
    private responsibleService: ResponsibleService,
    private routesService: RoutesService,
    private router: Router,
    private activateRoute: ActivatedRoute,) {

    this.editDealForm = new FormGroup({});
    this.error = false;
    this.messageError = "";
    this.subscription = [];

    this.deal = new Deal(Number.NaN, new Date(), "", 0, "", "", "");
    this.allSubscriptions = [];
    this.allClubCards = [];
    this.allClients = [];

    this.editDealForm = new FormGroup({
      id: new FormControl(0, [Validators.required]),
      purchaseDate: new FormControl(new Date(), []),
      subscriptionId: new FormControl("", [Validators.required]),
      clientId: new FormControl("", [Validators.required]),
      clubCardId: new FormControl("", [Validators.required]),
      responsibleId: new FormControl("", [Validators.required])
    });
  }

  public ngOnInit() {
    let id: number = this.activateRoute.snapshot.params['id'];
    if (id == 0) {
      this.redirectOnPageException();
    }

    let subGetDeal: Subscription = this.dealService.getDeal(id).subscribe((data: Deal) => {
      this.deal = data;

      let getUsers: Subscription = this.userSertvice.getUsers().subscribe({
        next: (data: Array<User>) => {
          this.allClients = data;
          let currentClientId: number = this.allClients.filter(x => x.name == this.deal.clientName)[0].id;
          this.editDealForm.controls['clientId'].setValue(currentClientId);
        }
      });
      this.subscription.push(getUsers);

      let getSubscription: Subscription = this.subscriptionService.getSubscriptionModelces().subscribe({
        next: (data: Array<SubscriptionModel>) => {
          this.allSubscriptions = data;
          this.allSubscriptions.push(new SubscriptionModel(0, 'Nothing', '', '', ''));
          let currentSubId: number = this.allSubscriptions.filter(x => x.name == this.deal.subscriptionName)[0].id;
          this.editDealForm.controls['subscriptionId'].setValue(currentSubId);
        }
      });
      this.subscription.push(getSubscription);

      let getClubCard: Subscription = this.clubCardService.getClubCardces().subscribe({
        next: (data: Array<ClubCard>) => {
          this.allClubCards = data;
          this.allClubCards.push(new ClubCard(0, 'Nothing', '', '', ''));
          let currentClubCardId: number = this.allClubCards.filter(x => x.name == this.deal.clubCardName)[0].id;
          this.editDealForm.controls['clubCardId'].setValue(currentClubCardId);
        }
      });
      this.subscription.push(getClubCard);

      this.editDealForm.controls['id'].setValue(this.deal.id);
      this.editDealForm.controls['purchaseDate'].setValue(this.deal.purchaseDate);

      let subGetResponsibleId: Subscription = this.responsibleService.getResponsibleIdByEmail(AuthActivateService.getSession()?.email ?? '').subscribe({
        next: (data: number) => {
          this.editDealForm.controls['responsibleId'].setValue(data)
        }
      })
      this.subscription.push(subGetResponsibleId);
    });

    this.subscription.push(subGetDeal)
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
      
      if(obg.subscriptionId == 0){
        obg.subscriptionId = null;
      }
      if(obg.clubCardId == 0){
        obg.clubCardId = null;
      }

      let updateDeal = new UpdateDeal
        (obg.id, obg.clientId, obg.responsibleId, obg.purchaseDate, obg.subscriptionId, obg.clubCardId);
        
      let subUpdateDeal: Subscription = this.dealService.updateDeal(updateDeal).subscribe({
        
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
      this.subscription.push(subUpdateDeal);
    }
  }

  ngOnDestroy(): void {
    this.subscription.forEach(x => x.unsubscribe());
  }

}
