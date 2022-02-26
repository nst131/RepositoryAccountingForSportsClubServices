import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ClubCard } from 'src/app/MainSite/Entities/club-card/models/club-card.model';
import { ClubCardService } from 'src/app/MainSite/Entities/club-card/services/club-card.service';
import { Serve } from 'src/app/MainSite/Entities/serve/model/serve.model';
import { ServeService } from 'src/app/MainSite/Entities/serve/services/serve.service';
import { RoutesService } from 'src/app/MainSite/services/routes.servic';
import { CreateClubCard } from './models/create-club-card.model';

@Component({
  selector: 'app-create-club-card',
  templateUrl: './create-club-card.component.html',
  styleUrls: ['./create-club-card.component.css'],
  providers: [ClubCardService, ServeService]
})
export class CreateClubCardComponent implements OnInit, OnDestroy {

  public editClubCardForm: FormGroup;
  public clubCard: ClubCard;
  public allServes: Array<Serve>;
  public response: any;
  private subscription: Subscription[];

  constructor(private clubCardService: ClubCardService,
    private router: Router,
    private serveService: ServeService,
    private routesService: RoutesService) {

    this.editClubCardForm = new FormGroup({});
    this.clubCard = new ClubCard(Number.NaN, "", "", "", "");
    this.allServes = [];
    this.subscription = [];

    this.editClubCardForm = new FormGroup({
      name: new FormControl("", [Validators.required, Validators.minLength(3)]),
      price: new FormControl("", [Validators.required, Validators.pattern("^[0-9]*$")]),
      durationInDays: new FormControl("", [Validators.required, Validators.pattern('^[0-9]*$')]),
      serviceId: new FormControl(0, [Validators.required])
    });
  }

  public ngOnInit() {
    let subGetAllServices : Subscription = this.serveService.getServeces().subscribe({
      next: (data: Array<Serve>) => {
        this.allServes = data;
        this.editClubCardForm.controls['serviceId'].setValue(this.allServes[0].id);
      }
    })

    this.subscription.push(subGetAllServices)
  }

  private redirectOnPageException() {
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['Exception'] } }]);
  }

  private redirectBack() {
    this.routesService.redirectOnPageAccount();
  }

  public onSubmit() {
    if (this.editClubCardForm.valid) {
      let obg = this.editClubCardForm.value;
      let createClubCard: CreateClubCard = new CreateClubCard(obg.name, Number(obg.price), Number(obg.durationInDays), Number(obg.serviceId));
      let subUpdateClubCard: Subscription = this.clubCardService.createClubCard(createClubCard).subscribe(x => {
        if (x.error) {
          this.redirectOnPageException();
        }
        else {
          this.response = x.response;
          this.editClubCardForm.reset;
          this.redirectBack();
        }
      });
      this.subscription.push(subUpdateClubCard);
    }
  }

  ngOnDestroy(): void {
    this.subscription.forEach(x => x.unsubscribe());
  }
}
