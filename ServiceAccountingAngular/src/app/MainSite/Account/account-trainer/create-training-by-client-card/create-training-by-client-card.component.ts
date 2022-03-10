import { Component, ElementRef, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthActivateService } from 'src/app/Auth/services/auth-activate.service';
import { TrainerService } from 'src/app/MainSite/Entities/trainer/service/trainer.service';
import { User } from 'src/app/MainSite/Entities/user/models/user.model';
import { UserService } from 'src/app/MainSite/Entities/user/services/user.service';
import { RoutesService } from 'src/app/MainSite/services/routes.servic';
import { CreateTraining } from '../models/create-training.model';
import { ResponseServe } from '../models/response-serve.model';
import { TrainingService } from '../services/traininig.service';

@Component({
  selector: 'app-create-training-by-client-card',
  templateUrl: './create-training-by-client-card.component.html',
  styleUrls: ['./create-training-by-client-card.component.css'],
  providers: [UserService, TrainerService, TrainingService]
})
export class CreateTrainingByClientCardComponent implements OnInit, OnDestroy {

  public editTrainingForm: FormGroup;
  public response: any;
  public error: boolean;
  public messageError: string;
  private subscription: Subscription[];

  public serve: ResponseServe;
  public allClients: Array<User>;

  constructor(
    private clientService: UserService,
    private trainerService: TrainerService,
    private trainingService: TrainingService,
    private router: Router,
    private routesService: RoutesService) {

    this.editTrainingForm = new FormGroup({});
    this.error = false;
    this.messageError = '';
    this.subscription = [];

    this.serve = new ResponseServe(Number.NaN, '');
    this.allClients = [];

    this.editTrainingForm = new FormGroup({
      name: new FormControl("", [Validators.required, Validators.minLength(3)]),
      startTraining: new FormControl(new Date(), []),
      clientsId: new FormControl("", []),
      serviceId: new FormControl("", [Validators.required]),
      trainerId: new FormControl("", [Validators.required])
    });
  }

  public ngOnInit() {

    let subGetAllClients: Subscription = this.clientService.getUsers().subscribe({
      next: (data: Array<User>) => {
        this.allClients = data;
      }
    })
    this.subscription.push(subGetAllClients);

    let subGetTrainerId: Subscription = this.trainerService.getTrainerIdByEmail(AuthActivateService.getSession()?.email ?? '').subscribe({
      next: (id: number) => {
        this.editTrainingForm.controls['trainerId'].setValue(id);

        let subGetAllServes: Subscription = this.trainerService.getServiceByTrainerId(id).subscribe({
          next: (data: ResponseServe) => {
            this.serve = data;
            this.editTrainingForm.controls['serviceId'].setValue(this.serve .id);
          }
        })
        this.subscription.push(subGetAllServes);

      },
      error: () => this.redirectOnPageException()
    })
    this.subscription.push(subGetTrainerId);

  }

  private redirectOnPageException() {
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['Exception'] } }]);
  }

  private redirectBack() {
    this.routesService.redirectOnPageAccount();
  }

  public onSubmit() {
    if (this.editTrainingForm.valid) {
      let obg = this.editTrainingForm.value;

      const elements: any = document.getElementsByClassName("form-check-input");
      const values: Array<number> = [];
      Array.from(elements).forEach((el: any) => {
        if (el.checked) {
          values.push(Number(el.value));
        }
      });

      let createTraining: CreateTraining = new CreateTraining(obg.name, obg.startTraining, obg.trainerId, obg.serviceId, values);
      let subCreateTraining: Subscription = this.trainingService.createTrainingByClubCard(createTraining).subscribe({

        next: (data: any) => {
          this.error = false;
          this.response = data.response;
          this.editTrainingForm.reset();
          this.redirectBack();
        },

        error: (err) => {
          let errors = err.error.errors;

          if (errors) {
            for (var i in errors) {
              if (errors.hasOwnProperty(i) && typeof (i) !== 'function') {
                this.messageError = errors[i][0].split('Path')[0];
                this.error = true;
                break;
              }
            }
          }
          else {
            this.error = false;
            this.redirectOnPageException();
          }
        }

      });
      this.subscription.push(subCreateTraining);
    }
  }

  ngOnDestroy(): void {
    this.subscription.forEach(x => x.unsubscribe());
  }

}
