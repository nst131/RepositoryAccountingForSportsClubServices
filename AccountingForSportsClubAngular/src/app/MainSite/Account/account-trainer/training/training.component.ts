import { Component, OnDestroy, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthActivateService } from 'src/app/Auth/services/auth-activate.service';
import { TrainerService } from 'src/app/MainSite/Entities/trainer/service/trainer.service';
import { Roles } from 'src/app/models/roles.enum';
import { Training } from '../models/training.model';
import { TrainingService } from '../services/traininig.service';

@Component({
  selector: 'app-training',
  templateUrl: './training.component.html',
  styleUrls: ['./training.component.css'],
  providers: [TrainingService, TrainerService]
})
export class TrainingComponent implements OnInit, OnDestroy {

  @ViewChild('readOnlyTemplate', { static: false }) readOnlyTemplate!: TemplateRef<any>;
  public trainings: Array<Training>;
  public trainingsName: Array<string>;
  public trainingKeys: Array<string>;
  private subscription: Subscription[];

  constructor(
    private trainingService: TrainingService,
    private trainerService: TrainerService,
    private router: Router) {

    this.trainings = new Array<Training>();
    this.trainingsName = [];
    this.trainingKeys = [];
    this.subscription = [];
  }

  private loadTrainings(): void {
    let subLoadTraining: Subscription = this.trainingService.getTrainings().subscribe({
      next: (data: Array<Training>) => {
        this.trainingsName = [];
        this.trainings = data;
        for (let key in data[0]) {
          if (key == 'id') continue;

          this.trainingsName.push(key.charAt(0).toUpperCase() + key.slice(1));
        }
      },
      error: (err) => {
        if (err.status == '403') {
          alert("Don't have acceess");
        }
        else {
          throw new Error("Cann't get Trainings")
        }
      }
    })

    this.subscription.push(subLoadTraining);
  }

  public delete(id: number): void {
    let deleteTrainingSubscription = this.trainingService.deleteTraining(id).subscribe({
      next: () => { this.loadTrainings() },
      error: (err) => {
        if (err.status = '403')
          alert("Don't have access")
      },
    })

    this.subscription.push(deleteTrainingSubscription);
  }

  public ngOnInit(): void {
    this.loadTrainings();
  }

  public loadTemplate(training: any): TemplateRef<any> {
    this.trainingKeys = [];

    for (const key in training) {
      if (key == 'id') continue;
      this.trainingKeys.push(training[key]);
    }

    return this.readOnlyTemplate;
  }

  public redirectOnEdit(id: number) {
    let role: string = AuthActivateService.getSession()?.role ?? '';
    let email: string = AuthActivateService.getSession()?.email ?? '';

    if (role == "") {
      alert("Don't have access");
      return;
    }

    switch (role) {
      case Roles.Administrator:
        this.routeOnEditTraining(id);
        break;
      case Roles.Trainer:
        let subGetTrainerIdByIdEmail: Subscription = this.trainerService.getTrainerIdByEmail(email.toLowerCase()).subscribe({
          next: (currentId: number) => {
            let subGetResponsibleIdByDealId: Subscription = this.trainingService.getTrainerIdByTrainingId(id).subscribe({
              next: (checkId: number) => { this.checkResemblanceIdWithCurrent(currentId, checkId, id) }
            })
            this.subscription.push(subGetResponsibleIdByDealId);
          },
          error: () => alert("Don't have access")
        });
        this.subscription.push(subGetTrainerIdByIdEmail);
        break;
      default: alert("Don't have access");
    }
  }

  private checkResemblanceIdWithCurrent(currentId: number, checkId: number, id: number) {
    if (currentId == checkId) {
      this.routeOnEditTraining(id);
    }
    else {
      alert("Don't have access");
    }
  }

  private routeOnEditTraining(id: number): void {
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['account-trainer', { outlets: { 'account': ['update-training-by-client-card', id] } }] } }]);
  }

  ngOnDestroy(): void {
    this.subscription.forEach((x) => {
      x.unsubscribe()
    });
  }

}
