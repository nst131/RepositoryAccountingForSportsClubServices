import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Serve } from 'src/app/MainSite/Entities/serve/model/serve.model';
import { ServeService } from 'src/app/MainSite/Entities/serve/services/serve.service';
import { User } from 'src/app/MainSite/Entities/user/models/user.model';
import { UserService } from 'src/app/MainSite/Entities/user/services/user.service';
import { RoutesService } from 'src/app/MainSite/services/routes.servic';
import { UpdateVisit } from '../models/update-visit.model';
import { Visit } from '../models/visit.model';
import { VisitService } from '../services/visit.service';

@Component({
  selector: 'app-update-visit',
  templateUrl: './update-visit.component.html',
  styleUrls: ['./update-visit.component.css'],
  providers:[ UserService, ServeService, VisitService]
})
export class UpdateVisitComponent implements OnInit, OnDestroy {

  public editVisitForm: FormGroup;
  public response: any;
  private subscription: Subscription[];

  public visit: Visit;
  public allServes: Array<Serve>;
  public allClients: Array<User>;

  constructor(
    private visitService: VisitService,
    private serveService: ServeService,
    private userSertvice:UserService,
    private routesService: RoutesService,
    private router: Router,
    private activateRoute: ActivatedRoute,) {

    this.editVisitForm = new FormGroup({}); 
    this.subscription = [];

    this.visit = new Visit(Number.NaN, new Date(), "", "");
    this.allServes = [];
    this.allClients = [];

    this.editVisitForm = new FormGroup({
      id: new FormControl(Number.NaN, [Validators.required]),
      arrival: new FormControl(new Date(), []),
      clientId: new FormControl("", [Validators.required]),
      serviceId: new FormControl("", [Validators.required])
    });
  }

  public ngOnInit() {
    let id: number = this.activateRoute.snapshot.params['id'];
    if (id == 0) {
      this.redirectOnPageException();
    }

    let subGetVisit: Subscription = this.visitService.getVisit(id).subscribe((data: Visit) => {
      this.visit = data;

      let getUsers: Subscription = this.userSertvice.getUsers().subscribe({
        next:(data: Array<User>) => {
          this.allClients = data;
          let currentClientId: number = this.allClients.filter(x => x.name == this.visit.clientName)[0].id;
          this.editVisitForm.controls['clientId'].setValue(currentClientId);
        }
      });
      this.subscription.push(getUsers);

      let getServes: Subscription = this.serveService.getServeces().subscribe({
        next:(data: Array<Serve>) => {
          this.allServes = data;
          let currentServeId: number = this.allServes.filter(x => x.name == this.visit.serviceName)[0].id;
          this.editVisitForm.controls['serviceId'].setValue(currentServeId);
        }
      });
      this.subscription.push(getServes);

      this.editVisitForm.controls['id'].setValue(this.visit.id);
      this.editVisitForm.controls['arrival'].setValue(this.visit.arrival);
    });

    this.subscription.push(subGetVisit)
  }

  private redirectOnPageException() {
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['Exception'] } }]);
  }

  private redirectBack() {
    this.routesService.redirectOnPageAccount();
  }

  public onSubmit() {
    if (this.editVisitForm.valid) {
      let obg = this.editVisitForm.value;
      let updateVisit = new UpdateVisit(Number(obg.id), obg.arrival, Number(obg.clientId), Number(obg.serviceId));
      let subUpdateVisit: Subscription = this.visitService.updateVisit(updateVisit).subscribe(x => {
        if (x.error) {
          this.redirectOnPageException();
        }
        else {
          this.response = x.response;
          this.editVisitForm.reset;
          this.redirectBack();
        }
      });
      this.subscription.push(subUpdateVisit);
    }
  }

  ngOnDestroy(): void {
    this.subscription.forEach(x => x.unsubscribe());
  }
  
}
