import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Place } from '../../place/models/place.model';
import { PlaceService } from '../../place/services/place.service';
import { ServeUpdate } from '../model/serve-update.model';
import { Serve } from '../model/serve.model';
import { ServeService } from '../services/serve.service';

@Component({
  selector: 'app-serve-update',
  templateUrl: './serve-update.component.html',
  styleUrls: ['./serve-update.component.css'],
  providers: [ServeService, PlaceService]
})
export class ServeUpdateComponent implements OnInit, OnDestroy {

  public editServeForm: FormGroup;
  public serve: Serve;
  public response: any;
  public allPlaces: Array<Place>;
  private subscription: Subscription[];

  constructor(private serveService: ServeService,
    private router: Router,
    private activateRoute: ActivatedRoute,
    private placeService: PlaceService) {

    this.editServeForm = new FormGroup({});
    this.serve = new Serve(Number.NaN, "", "", "", "");
    this.allPlaces = [];
    this.subscription = [];

    this.editServeForm = new FormGroup({
      id: new FormControl(0, [Validators.required]),
      name: new FormControl("", [Validators.required, Validators.minLength(3)]),
      price: new FormControl("", [Validators.required, Validators.pattern("^[0-9]*$")]),
      durationInMinutes: new FormControl("", [Validators.required, Validators.pattern("^[0-9]*$")]),
      placeId: new FormControl(0, [Validators.required])
    });
  }

  public ngOnInit() {
    let id: number = this.activateRoute.snapshot.params['id'];
    if (id == 0) {
      this.redirectOnPageException();
    }

    let subGetServe: Subscription = this.serveService.getServe(id).subscribe((data: Serve) => {
      this.serve = data;

      this.editServeForm.controls['id'].setValue(this.serve.id);
      this.editServeForm.controls['name'].setValue(this.serve.name);
      this.editServeForm.controls['price'].setValue(this.serve.price);
      this.editServeForm.controls['durationInMinutes'].setValue(this.serve.durationInMinutes);

      let subGetAllPlace: Subscription = this.placeService.getPlaceces().subscribe({
        next: (data: Array<Place>) => {
          this.allPlaces = data;
          let currentIdPlace = this.allPlaces.filter(x => x.name == this.serve.placeName)[0].id;
          this.editServeForm.controls['placeId'].setValue(currentIdPlace);
        }
      })

      this.subscription.push(subGetAllPlace);
    });

    this.subscription.push(subGetServe)
  }

  private redirectOnPageException() {
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['Exception'] } }]);
  }

  private redirectBack() {
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['service'] } }]);
  }

  public onSubmit() {
    if (this.editServeForm.valid) {
      let obg = this.editServeForm.value;
      let updateServe: ServeUpdate = new ServeUpdate(Number(obg.id), obg.name, Number(obg.price), Number(obg.durationInMinutes), Number(obg.placeId));
      let subUpdateServe: Subscription = this.serveService.updateServe(updateServe).subscribe(x => {
        if (x.error) {
          this.redirectOnPageException();
        }
        else {
          this.response = x.response;
          this.editServeForm.reset;
          this.redirectBack();
        }
      });
      this.subscription.push(subUpdateServe);
    }
  }

  ngOnDestroy(): void {
    this.subscription.forEach(x => x.unsubscribe());
  }

}
