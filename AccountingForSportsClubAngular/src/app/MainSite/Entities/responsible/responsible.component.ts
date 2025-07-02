import { Component, OnDestroy, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthActivateService } from 'src/app/Auth/services/auth-activate.service';
import { Roles } from 'src/app/models/roles.enum';
import { Responsible } from './models/responsible.model';
import { ResponsibleService } from './service/responsible.service';

@Component({
  selector: 'app-responsible',
  templateUrl: './responsible.component.html',
  styleUrls: ['./responsible.component.css'],
  providers: [ResponsibleService]
})
export class ResponsibleComponent implements OnInit, OnDestroy {

  @ViewChild('readOnlyTemplate', { static: false }) readOnlyTemplate!: TemplateRef<any>;
  public responsibles: Array<Responsible>;
  public responsiblesName: Array<string>;
  public responsibleKeys: Array<string>;
  private subscription: Subscription[];

  constructor(private responsibleService: ResponsibleService, private router: Router) {
    this.responsibles = new Array<Responsible>();
    this.responsiblesName = [];
    this.responsibleKeys = [];
    this.subscription = [];
  }

  private loadResponsibles(): void {
    let subLoadResponsible: Subscription = this.responsibleService.getResponsibles().subscribe({
      next: (data: Array<Responsible>) => {
        this.responsiblesName = [];
        this.responsibles = data;
        for (let key in data[0]) {
          if (key == 'id' || key == 'email') continue;

          this.responsiblesName.push(key.charAt(0).toUpperCase() + key.slice(1));
        }
      },
      error: (err) => {
        if (err.status == '403') {
          alert("Don't have acceess");
        }
        else {
          throw new Error("Cann't get Responsibles")
        }
      }
    })

    this.subscription.push(subLoadResponsible);
  }

  public deleteResponsible(id: number): void {
    let deleteResponsibleSubscription = this.responsibleService.deleteResponsible(id).subscribe({
      next: () => { this.loadResponsibles() },
      error: (err) => {
        if (err.status = '403')
        alert("Don't have access")
      },
    })

    this.subscription.push(deleteResponsibleSubscription);
  }

  public ngOnInit(): void {
    this.loadResponsibles();
  }

  public loadTemplate(responsible: any): TemplateRef<any> {
    this.responsibleKeys = [];

    for (const key in responsible) {
      if (key == 'id' || key == 'email') continue;
      this.responsibleKeys.push(responsible[key]);
    }

    return this.readOnlyTemplate;
  }

  public redirectOnEditResponsible(id: number) {
    let role: string = AuthActivateService.getSession()?.role ?? "";
    let email: string = AuthActivateService.getSession()?.email ?? "";
    if (role == "") {
      alert("Don't have access");
      return;
    }

    switch (role) {
      case Roles.Administrator:
        this.routeOnEditResponsible(id);
        break;
      case Roles.Responsible:
        let subGetResponsibleByIdEmail: Subscription = this.responsibleService.getResponsibleIdByEmail(email.toLowerCase()).subscribe({
          next: (currentId: number) => this.checkResemblanceIdWithCurrent(currentId, id),
          error: () => alert("Don't have access")
        });
        this.subscription.push(subGetResponsibleByIdEmail);
        break;
      default: alert("Don't have access");
    }
  }

  private checkResemblanceIdWithCurrent(currentId: number, id: number) {
    if (currentId == id) {
      this.routeOnEditResponsible(id);
    }
    else {
      alert("Don't have access");
    }
  }

  private routeOnEditResponsible(id: number): void {
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['responsible', 'edit-responsible', id] } }]);
  }

  ngOnDestroy(): void {
    this.subscription.forEach((x) => { x.unsubscribe() });
  }

}
