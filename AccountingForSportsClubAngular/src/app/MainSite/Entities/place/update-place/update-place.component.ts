import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { PlaceUpdate } from '../models/place-update.model';
import { Place } from '../models/place.model';
import { PlaceService } from '../services/place.service';

@Component({
  selector: 'app-update-place',
  templateUrl: './update-place.component.html',
  styleUrls: ['./update-place.component.css'],
  providers: [PlaceService]
})
export class UpdatePlaceComponent implements OnInit, OnDestroy {

  public editPlaceForm: FormGroup;
  public place: Place;
  public response: any;
  private subscription: Subscription[];

  constructor(
    private router: Router,
    private activateRoute: ActivatedRoute,
    private placeService: PlaceService) {

    this.editPlaceForm = new FormGroup({});
    this.place = new Place(Number.NaN, "", Number.NaN);
    this.subscription = [];

    this.editPlaceForm = new FormGroup({
      id: new FormControl(0, [Validators.required]),
      name: new FormControl("", [Validators.required, Validators.minLength(3)]),
      amountFreePlace: new FormControl("", [Validators.required, Validators.pattern("^[0-9]*$")]),
    });
  }

  public ngOnInit() {
    let id: number = this.activateRoute.snapshot.params['id'];
    if (id == 0) {
      this.redirectOnPageException();
    }

    let subGetPlace: Subscription = this.placeService.getPlace(id).subscribe((data: Place) => {
      this.place = data;

      this.editPlaceForm.controls['id'].setValue(this.place.id);
      this.editPlaceForm.controls['name'].setValue(this.place.name);
      this.editPlaceForm.controls['amountFreePlace'].setValue(this.place.amountFreePlace);
    });

    this.subscription.push(subGetPlace)
  }

  private redirectOnPageException() {
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['Exception'] } }]);
  }

  private redirectBack() {
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['place'] } }]);
  }

  public onSubmit() {
    if (this.editPlaceForm.valid) {
      let obg = this.editPlaceForm.value;
      let updatePlace: PlaceUpdate = new PlaceUpdate(Number(obg.id), obg.name, Number(obg.amountFreePlace));
      let subUpdatePlace: Subscription = this.placeService.updatePlace(updatePlace).subscribe(x => {
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
