import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { TypeOfServeModel } from 'src/app/MainSite/models/type-of-serve.model';
import { TypeOfSexModel } from 'src/app/MainSite/models/type-of-sex.model';
import { LoadTypeOfSexService } from 'src/app/MainSite/services/load-type-of-sex';
import { Serve } from '../../serve/model/serve.model';
import { ServeService } from '../../serve/services/serve.service';
import { TrainerUpdate } from '../models/trainer-update.model';
import { Trainer } from '../models/trainer.model';
import { TrainerService } from '../service/trainer.service';

@Component({
  selector: 'app-trainer-update',
  templateUrl: './trainer-update.component.html',
  styleUrls: ['./trainer-update.component.css'],
  providers: [TrainerService, LoadTypeOfSexService, ServeService]
})
export class TrainerUpdateComponent implements OnInit, OnDestroy {
  public id: number;
  public editTrainerForm: FormGroup;
  public trainer: Trainer;
  public viewsTypeOfSex: Array<TypeOfSexModel>;
  public response: any;
  public viewsTypeOfServe: Array<TypeOfServeModel>;
  private subscription: Subscription[];

  constructor(private trainerService: TrainerService,
    private loadTypeOfSex: LoadTypeOfSexService,
    private router: Router,
    private activateRoute: ActivatedRoute,
    private serveService: ServeService) {

    this.id = 0;
    this.editTrainerForm = new FormGroup({});
    this.trainer = new Trainer(Number.NaN, "", "", "", "", Number.NaN, "", "");
    this.viewsTypeOfSex = [];
    this.viewsTypeOfServe = [];
    this.subscription = [];

    this.editTrainerForm = new FormGroup({
      serName: new FormControl("", [Validators.required, Validators.minLength(3)]),
      telephone: new FormControl("", [Validators.required, Validators.pattern('[0-9]{2} [0-9]{3}-[0-9]{2}-[0-9]{2}')]),
      typeSexId: new FormControl(0, [Validators.required]),
      serviceId: new FormControl(0, [Validators.required]),
    });
  }

  public ngOnInit() {
    this.id = this.activateRoute.snapshot.params['id'];
    if (this.id == 0) {
      this.redirectOnPageException();
    }
    this.viewsTypeOfSex = this.loadTypeOfSex.GetViewsTypeOfSex();
    let subGetTrainer: Subscription = this.trainerService.getTrainer(this.id).subscribe({
      next: (data: Trainer) => {
        this.trainer = data;
        let currentTypeOfSex: number = this.viewsTypeOfSex.filter(x => x.name == this.trainer.typeSex)[0].value;
        this.editTrainerForm.controls['serName'].setValue(this.trainer.serName);
        this.editTrainerForm.controls['telephone'].setValue(this.trainer.telephone);
        this.editTrainerForm.controls['typeSexId'].setValue(currentTypeOfSex);
        if(this.trainer.serviceId == 0){
          this.editTrainerForm.controls['serviceId'].setValue(1)  
        }
        else{
          this.editTrainerForm.controls['serviceId'].setValue(this.trainer.serviceId)
        }
      },
      error: () => {this.redirectOnPageException()}
    });

    let subGetServices: Subscription = this.serveService.getServeces().subscribe({
      next: (data: Array<Serve>) => {
        data.forEach((serve: Serve) => {
          this.viewsTypeOfServe.push(new TypeOfServeModel(serve.name, serve.id));
        })
      },
      error: () => { this.redirectOnPageException() }
    })

    this.subscription.push(subGetTrainer, subGetServices);
  }

  private redirectOnPageException() {
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['Exception'] } }]);
  }

  private redirectBack() {
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['trainer'] } }]);
  }

  public onSubmit() {
    if (this.editTrainerForm.valid) {
      let obg = this.editTrainerForm.value;
      let updateTrainer = new TrainerUpdate(
        Number(this.id), this.trainer.name, obg.serName, obg.telephone, Number(obg.typeSexId), Number(obg.serviceId));
      let subUpdateTrainer: Subscription = this.trainerService.updateTrainer(updateTrainer).subscribe({
        next: (data: any) => {
          this.response = data;
          this.editTrainerForm.reset;
          this.redirectBack();
        },
        error: () => { this.redirectOnPageException() }
      });
      this.subscription.push(subUpdateTrainer);
    }
  }

  ngOnDestroy(): void {
    this.subscription.forEach(x => x.unsubscribe());
  }
}
