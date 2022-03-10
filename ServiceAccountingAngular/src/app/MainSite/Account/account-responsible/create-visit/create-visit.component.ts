import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Serve } from 'src/app/MainSite/Entities/serve/model/serve.model';
import { ServeService } from 'src/app/MainSite/Entities/serve/services/serve.service';
import { User } from 'src/app/MainSite/Entities/user/models/user.model';
import { UserService } from 'src/app/MainSite/Entities/user/services/user.service';
import { RoutesService } from 'src/app/MainSite/services/routes.servic';
import { CreateVisit } from '../models/create-visit.model';
import { VisitService } from '../services/visit.service';

@Component({
  selector: 'app-create-visit',
  templateUrl: './create-visit.component.html',
  styleUrls: ['./create-visit.component.css'],
  providers:[ UserService, ServeService, VisitService]
})
export class CreateVisitComponent implements OnInit, OnDestroy {

  public editVisitForm: FormGroup;
  public response: any;
  private subscription: Subscription[];

  public allServes: Array<Serve>;
  public allClients: Array<User>;

  constructor(
    private clientService: UserService,
    private serveService: ServeService,
    private visitService: VisitService,
    private router: Router,
    private routesService: RoutesService) {

    this.editVisitForm = new FormGroup({});
    this.subscription = [];

    this.allServes = [];
    this.allClients = [];

    this.editVisitForm = new FormGroup({
      arrival: new FormControl(new Date(), []),
      clientId: new FormControl("", [Validators.required]),
      serviceId: new FormControl("", [Validators.required])
    });
  }

  public ngOnInit() {

    let subGetAllServes: Subscription = this.serveService.getServeces().subscribe({
      next: (data: Array<Serve>) => {
        this.allServes = data;
        this.editVisitForm.controls['serviceId'].setValue(this.allServes[0].id);
      }
    })
    this.subscription.push(subGetAllServes);

    let subGetAllClients: Subscription = this.clientService.getUsers().subscribe({
      next: (data: Array<User>) => {
        this.allClients = data;
        this.editVisitForm.controls['clientId'].setValue(this.allClients[0].id);
      }
    })
    this.subscription.push(subGetAllClients);

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
      let createVisit: CreateVisit = new CreateVisit(obg.arrival, Number(obg.clientId), Number(obg.serviceId));
      let subUpdateVisit: Subscription = this.visitService.createVisit(createVisit).subscribe(x => {
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
