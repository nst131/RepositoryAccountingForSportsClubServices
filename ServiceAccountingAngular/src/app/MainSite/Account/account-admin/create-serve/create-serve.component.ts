import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Place } from 'src/app/MainSite/Entities/place/models/place.model';
import { PlaceService } from 'src/app/MainSite/Entities/place/services/place.service';
import { ServeService } from 'src/app/MainSite/Entities/serve/services/serve.service';
import { RoutesService } from 'src/app/MainSite/services/routes.servic';
import { CreateServe } from './model/create-serve.model';

@Component({
  selector: 'app-create-serve',
  templateUrl: './create-serve.component.html',
  styleUrls: ['./create-serve.component.css'],
  providers: [ServeService, PlaceService]
})
export class CreateServeComponent implements OnInit, OnDestroy {

  public editServeForm: FormGroup;
  public allPlaces: Array<Place>
  public response: any;
  private subscription: Subscription[];

  constructor(private serveService: ServeService,
    private router: Router,
    private placeService: PlaceService,
    private routesService: RoutesService) {

    this.editServeForm = new FormGroup({});
    this.allPlaces = [];
    this.subscription = [];

    this.editServeForm = new FormGroup({
      name: new FormControl("", [Validators.required, Validators.minLength(3)]),
      price: new FormControl("", [Validators.required, Validators.pattern("^[0-9]*$")]),
      durationInMinutes: new FormControl("", [Validators.required, Validators.pattern('^[0-9]*$')]),
      placeId: new FormControl(0, [Validators.required])
    });
  }

  public ngOnInit() {

    let subGetAllPlaces : Subscription = this.placeService.getPlaceces().subscribe({
      next: (data: Array<Place>) => {
        this.allPlaces = data;
        this.editServeForm.controls['placeId'].setValue(this.allPlaces[0].id);
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
    if (this.editServeForm.valid) {
      let obg = this.editServeForm.value;
      let createServe: CreateServe = new CreateServe(obg.name, Number(obg.price), Number(obg.durationInMinutes), Number(obg.placeId));
      let subUpdateServe: Subscription = this.serveService.createServe(createServe).subscribe(x => {
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
