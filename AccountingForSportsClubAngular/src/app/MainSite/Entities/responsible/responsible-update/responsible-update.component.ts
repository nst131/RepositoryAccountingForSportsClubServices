import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ResponsibleUpdate } from '../models/responsible-update.model';
import { Responsible } from '../models/responsible.model';
import { ResponsibleService } from '../service/responsible.service';

@Component({
  selector: 'app-responsible-update',
  templateUrl: './responsible-update.component.html',
  styleUrls: ['./responsible-update.component.css'],
  providers: [ResponsibleService]
})
export class ResponsibleUpdateComponent implements OnInit, OnDestroy {

  public id: number;
  public editResponsibleForm: FormGroup;
  public responsible: Responsible;
  public response: any;
  private subscription: Subscription[];

  constructor(private responsibleService: ResponsibleService,
    private router: Router,
    private activateRoute: ActivatedRoute) {

    this.id = 0;
    this.editResponsibleForm = new FormGroup({});
    this.responsible = new Responsible(Number.NaN, "", "", "", "");
    this.subscription = [];

    this.editResponsibleForm = new FormGroup({
      serName: new FormControl("", [Validators.required, Validators.minLength(3)]),
      telephone: new FormControl("", [Validators.required, Validators.pattern('[0-9]{2} [0-9]{3}-[0-9]{2}-[0-9]{2}')])
    });
  }

  public ngOnInit() {
    this.id = this.activateRoute.snapshot.params['id'];
    if (this.id == 0) {
      this.redirectOnPageException();
    }
    let subGetResponsible: Subscription = this.responsibleService.getResponsible(this.id).subscribe({
      next: (data: Responsible) => {
        this.responsible = data;

        this.editResponsibleForm.controls['serName'].setValue(this.responsible.serName);
        this.editResponsibleForm.controls['telephone'].setValue(this.responsible.telephone);
      },
      error: () => {this.redirectOnPageException()}
    });

    this.subscription.push(subGetResponsible);
  }

  private redirectOnPageException() {
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['Exception'] } }]);
  }

  private redirectBack() {
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['responsible'] } }]);
  }

  public onSubmit() {
    if (this.editResponsibleForm.valid) {
      let obg = this.editResponsibleForm.value;
      let updateResponsible = new ResponsibleUpdate(Number(this.id), this.responsible.name, obg.serName, obg.telephone);
      let subUpdateResponsible: Subscription = this.responsibleService.updateResponsible(updateResponsible).subscribe({
        next: (data: any) => {
          this.response = data;
          this.editResponsibleForm.reset;
          this.redirectBack();
        },
        error: () => { this.redirectOnPageException() }
      });
      this.subscription.push(subUpdateResponsible);
    }
  }

  ngOnDestroy(): void {
    this.subscription.forEach(x => x.unsubscribe());
  }

}
