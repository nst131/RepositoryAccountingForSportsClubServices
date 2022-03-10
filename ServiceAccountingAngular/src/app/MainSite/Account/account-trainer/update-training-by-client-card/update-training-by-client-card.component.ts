import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Serve } from 'src/app/MainSite/Entities/serve/model/serve.model';
import { ServeService } from 'src/app/MainSite/Entities/serve/services/serve.service';
import { Trainer } from 'src/app/MainSite/Entities/trainer/models/trainer.model';
import { TrainerService } from 'src/app/MainSite/Entities/trainer/service/trainer.service';
import { User } from 'src/app/MainSite/Entities/user/models/user.model';
import { UserService } from 'src/app/MainSite/Entities/user/services/user.service';
import { RoutesService } from 'src/app/MainSite/services/routes.servic';
import { ResponseServe } from '../models/response-serve.model';
import { Training } from '../models/training.model';
import { UpdateTraining } from '../models/update-training.model';
import { TrainingService } from '../services/traininig.service';

@Component({
  selector: 'app-update-training-by-client-card',
  templateUrl: './update-training-by-client-card.component.html',
  styleUrls: ['./update-training-by-client-card.component.css'],
  providers: [UserService, TrainerService, TrainingService, ServeService]
})
export class UpdateTrainingByClientCardComponent implements OnInit, OnDestroy {

  public editTrainingForm: FormGroup;
  public response: any;
  public error: boolean;
  public messageError: string;
  private subscription: Subscription[];

  public training: Training;
  public serve: ResponseServe;
  public allClients: Array<User>;

  constructor(
    private trainingService: TrainingService,
    private clientService: UserService,
    private trainerService: TrainerService,
    private serveService: ServeService,
    private routesService: RoutesService,
    private router: Router,
    private activateRoute: ActivatedRoute,) {

    this.editTrainingForm = new FormGroup({});
    this.error = true;
    this.messageError = '';
    this.serve = new ResponseServe(Number.NaN, '');
    this.subscription = [];

    this.training = new Training(Number.NaN, "", new Date(), new Date(), "", "");
    this.allClients = [];

    this.editTrainingForm = new FormGroup({
      id: new FormControl("", [Validators.required]),
      name: new FormControl("", [Validators.required, Validators.minLength(3)]),
      startTraining: new FormControl(new Date(), []),
      clientsId: new FormControl("", []),
      serviceId: new FormControl("", [Validators.required]),
      trainerId: new FormControl("", [Validators.required])
    });
  }

  public ngOnInit() {
    let id: number = this.activateRoute.snapshot.params['id'];
    if (id == 0) {
      this.redirectOnPageException();
    }

    let subGetTraining: Subscription = this.trainingService.getTraining(id).subscribe({
      next: (data: Training) => {
        this.training = data;
        this.editTrainingForm.controls['id'].setValue(this.training.id);
        this.editTrainingForm.controls['name'].setValue(this.training.name);

        let subGetTrainers : Subscription = this.trainerService.getTrainers().subscribe({
          next: (trainers: Array<Trainer>) => {
            let currentTrainer: Trainer = trainers.filter(x => x.name == this.training.trainerName)[0];
            this.editTrainingForm.controls['trainerId'].setValue(currentTrainer.id);

            let subGetServe : Subscription = this.serveService.getServe(currentTrainer.serviceId).subscribe({
              next:(data: Serve) => {
                this.serve = new ResponseServe(data.id, data.name);
                this.editTrainingForm.controls['serviceId'].setValue(data.id);
              }
            })
            this.subscription.push(subGetServe);
          }
        })
        this.subscription.push(subGetTrainers);
      }
    })
    this.subscription.push(subGetTraining);

    let subGetAllClients : Subscription = this.clientService.getUsers().subscribe({
      next: (data: Array<User>) => {
        this.allClients = data; 
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
    if (this.editTrainingForm.valid) {
      let obg = this.editTrainingForm.value;

      const elements: any = document.getElementsByClassName("form-check-input");
      const values: Array<number> = [];
      Array.from(elements).forEach((el: any) => {
        if (el.checked) {
          values.push(Number(el.value));
        }
      });

      let updateTraining: UpdateTraining = new UpdateTraining(obg.id, obg.name, obg.startTraining, obg.trainerId, obg.serviceId, values);
      let subUpdateTraining: Subscription = this.trainingService.updateTrainingByClubCard(updateTraining).subscribe({

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
      this.subscription.push(subUpdateTraining);
    }
  }

  ngOnDestroy(): void {
    this.subscription.forEach(x => x.unsubscribe());
  }

}
