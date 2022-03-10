import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Place } from 'src/app/MainSite/Entities/place/models/place.model';
import { PlaceService } from 'src/app/MainSite/Entities/place/services/place.service';
import { RoutesService } from 'src/app/MainSite/services/routes.servic';
import { CreatePlace } from './models/create-place.model';

@Component({
  selector: 'app-create-place',
  templateUrl: './create-place.component.html',
  styleUrls: ['./create-place.component.css'],
  providers: [PlaceService]
})
export class CreatePlaceComponent implements OnDestroy {
  public editPlaceForm: FormGroup;
  public place: Place;
  public response: any;
  private subscription: Subscription[];

  constructor(
    private router: Router,
    private placeService: PlaceService,
    private routesService: RoutesService) {

    this.editPlaceForm = new FormGroup({});
    this.place = new Place(Number.NaN, "", Number.NaN);
    this.subscription = [];

    this.editPlaceForm = new FormGroup({
      name: new FormControl("", [Validators.required, Validators.minLength(3)]),
      amountFreePlace: new FormControl("", [Validators.required, Validators.pattern("^[0-9]*$")]),
    });
  }

  private redirectOnPageException() {
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['Exception'] } }]);
  }

  private redirectBack() {
    this.routesService.redirectOnPageAccount();
  }

  public onSubmit() {
    if (this.editPlaceForm.valid) {
      let obg = this.editPlaceForm.value;
      let createPlace: CreatePlace= new CreatePlace( obg.name, Number(obg.amountFreePlace));
      let subUpdatePlace: Subscription = this.placeService.createPlace(createPlace).subscribe(x => {
        if (x.error) {
          this.redirectOnPageException();
        }
        else {
          this.response = x.response;
          this.editPlaceForm.reset;
          this.redirectBack();
        }
      });
      this.subscription.push(subUpdatePlace);
    }
  }

  ngOnDestroy(): void {
    this.subscription.forEach(x => x.unsubscribe());
  }
}
