import { Component, OnDestroy, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthActivateService } from 'src/app/Auth/services/auth-activate.service';
import { Roles } from 'src/app/models/roles.enum';
import { Place } from './models/place.model';
import { PlaceService } from './services/place.service';

@Component({
  selector: 'app-place',
  templateUrl: './place.component.html',
  styleUrls: ['./place.component.css'],
  providers: [PlaceService]
})
export class PlaceComponent implements OnInit, OnDestroy {

  @ViewChild('readOnlyTemplate', { static: false }) readOnlyTemplate!: TemplateRef<any>;
  public places: Array<Place>;
  public placesName: Array<string>;
  public placeKeys: Array<string>;
  private subscription: Subscription[];

  constructor(private placeService: PlaceService, private router: Router) {
    this.places = new Array<Place>();
    this.placesName = [];
    this.placeKeys = [];
    this.subscription = [];
  }

  private loadPlaces(): void {
    let subLoadPlaces: Subscription = this.placeService.getPlaceces().subscribe({
      next: (data: Array<Place>) => {
        this.placesName = [];
        this.places = data;
        for (let key in data[0]) {
          if (key == 'id') continue;

          this.placesName.push(key.charAt(0).toUpperCase() + key.slice(1));
        }
      },
      error: (err) => {
        if (err.status == '403') {
          alert("Don't have acceess");
        }
        else {
          throw new Error("Cann't get Places")
        }
      }
    })

    this.subscription.push(subLoadPlaces);
  }

  public deletePlace(id: number): void {
    let deletePlaceSubscription = this.placeService.deletePlace(id).subscribe({
      next: () => { this.loadPlaces() },
      error: (err) => {
        if (err.status = '403')
          alert("Don't have access")
      },
    })

    this.subscription.push(deletePlaceSubscription);
  }

  public ngOnInit(): void {
    this.loadPlaces();
  }

  public loadTemplate(place: any): TemplateRef<any> {
    this.placeKeys = [];

    for (const key in place) {
      if (key == 'id') continue;
      this.placeKeys.push(place[key]);
    }

    return this.readOnlyTemplate;
  }

  public redirectOnEditPlace(id: number) {
    let role: string = AuthActivateService.getSession()?.role ?? "";
    if (role == "") {
      alert("Don't have access");
      return;
    }

    switch (role) {
      case Roles.Administrator:
        this.routeOnEditPlace(id);
        break;
      default: alert("Don't have access");
    }
  }

  private routeOnEditPlace(id: number): void {
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['place', 'edit-place', id] } }]);
  }

  ngOnDestroy(): void {
    this.subscription.forEach((x) => { x.unsubscribe() });
  }

}
