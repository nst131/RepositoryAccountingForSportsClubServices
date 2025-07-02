import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Serve } from '../../serve/model/serve.model';
import { ServeService } from '../../serve/services/serve.service';
import { ClubCard } from '../models/club-card.model';
import { UpdateClubCard } from '../models/update-club-card.model';
import { ClubCardService } from '../services/club-card.service';

@Component({
  selector: 'app-update-club-card',
  templateUrl: './update-club-card.component.html',
  styleUrls: ['./update-club-card.component.css'],
  providers: [ClubCardService, ServeService]
})
export class UpdateClubCardComponent implements OnInit, OnDestroy {

  public editClubCardForm: FormGroup;
  public clubCard: ClubCard;
  public response: any;
  public allServes: Array<Serve>;
  private subscription: Subscription[];

  constructor(private clubCardService: ClubCardService,
    private router: Router,
    private activateRoute: ActivatedRoute,
    private serveService: ServeService) {

    this.editClubCardForm = new FormGroup({});
    this.clubCard = new ClubCard(Number.NaN, "", "", "", "");
    this.allServes = [];
    this.subscription = [];

    this.editClubCardForm = new FormGroup({
      id: new FormControl(0, [Validators.required]),
      name: new FormControl("", [Validators.required, Validators.minLength(3)]),
      price: new FormControl("", [Validators.required, Validators.pattern("^[0-9]*$")]),
      durationInDays: new FormControl("", [Validators.required, Validators.pattern("^[0-9]*$")]),
      serviceId: new FormControl(0, [Validators.required])
    });
  }

  public ngOnInit() {
    let id: number = this.activateRoute.snapshot.params['id'];
    if (id == 0) {
      this.redirectOnPageException();
    }

    let subGetClubCard: Subscription = this.clubCardService.getClubCard(id).subscribe((data: ClubCard) => {
      this.clubCard = data;

      this.editClubCardForm.controls['id'].setValue(this.clubCard.id);
      this.editClubCardForm.controls['name'].setValue(this.clubCard.name);
      this.editClubCardForm.controls['price'].setValue(this.clubCard.price);
      this.editClubCardForm.controls['durationInDays'].setValue(this.clubCard.durationInDays);

      let subGetAllServes: Subscription = this.serveService.getServeces().subscribe({
        next: (data: Array<Serve>) => {
          this.allServes = data;
          let currentIdServe = this.allServes.filter(x => x.name == this.clubCard.service)[0].id;
          this.editClubCardForm.controls['serviceId'].setValue(currentIdServe);
        }
      })

      this.subscription.push(subGetAllServes);
    });

    this.subscription.push(subGetClubCard)
  }

  private redirectOnPageException() {
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['Exception'] } }]);
  }

  private redirectBack() {
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['club-card'] } }]);
  }

  public onSubmit() {
    if (this.editClubCardForm.valid) {
      let obg = this.editClubCardForm.value;
      let updateClubCard: UpdateClubCard = new UpdateClubCard(Number(obg.id), obg.name, Number(obg.price), Number(obg.durationInDays), Number(obg.serviceId));
      let subUpdateClubCard: Subscription = this.clubCardService.updateClubCard(updateClubCard).subscribe(x => {
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
