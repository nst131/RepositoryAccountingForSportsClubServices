import { Component, OnDestroy, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthActivateService } from 'src/app/Auth/services/auth-activate.service';
import { Roles } from 'src/app/models/roles.enum';
import { Trainer } from './models/trainer.model';
import { TrainerService } from './service/trainer.service';

@Component({
  selector: 'app-trainer',
  templateUrl: './trainer.component.html',
  styleUrls: ['./trainer.component.css'],
  providers: [TrainerService]
})
export class TrainerComponent implements OnInit, OnDestroy {
  @ViewChild('readOnlyTemplate', { static: false }) readOnlyTemplate!: TemplateRef<any>;
  public trainers: Array<Trainer>;
  public trainersName: Array<string>;
  public trainerKeys: Array<string>;
  private subscription: Subscription[];

  constructor(private trainerService: TrainerService, private router: Router) {
    this.trainers = new Array<Trainer>();
    this.trainersName = [];
    this.trainerKeys = [];
    this.subscription = [];
  }

  private loadTrainers(): void {
    let subLoadTrainer: Subscription = this.trainerService.getTrainers().subscribe({
      next: (data: Array<Trainer>) => {
        this.trainersName = [];
        this.trainers = data;
        for (let key in data[0]) {
          if (key == 'id' || key == 'email' || key == 'serviceId') continue;

          this.trainersName.push(key.charAt(0).toUpperCase() + key.slice(1));
        }
      },
      error: (err) => {
        if (err.status == '403') {
          alert("Don't have acceess");
        }
        else {
          throw new Error("Cann't get Trainers")
        }
      }
    })

    this.subscription.push(subLoadTrainer);
  }

  public deleteTrainer(id: number): void {
    let deleteTrainerSubscription = this.trainerService.deleteTrainer(id).subscribe({
      next: () => { this.loadTrainers() },
      error: (err) => {
        if (err.status = '403')
        alert("Don't have access")
      },
    })

    this.subscription.push(deleteTrainerSubscription);
  }

  public ngOnInit(): void {
    this.loadTrainers();
  }

  public loadTemplate(trainer: any): TemplateRef<any> {
    this.trainerKeys = [];

    for (const key in trainer) {
      if (key == 'id' || key == 'email' || key == 'serviceId') continue;
      this.trainerKeys.push(trainer[key]);
    }

    return this.readOnlyTemplate;
  }

  public redirectOnEditTrainer(id: number) {
    let role: string = AuthActivateService.getSession()?.role ?? "";
    let email: string = AuthActivateService.getSession()?.email ?? "";
    if (role == "") {
      alert("Don't have access");
      return;
    }

    switch (role) {
      case Roles.Administrator:
        this.routeOnEditTrainer(id);
        break;
      case Roles.Trainer:
        let subGetTrainerByIdEmail: Subscription = this.trainerService.getTrainerIdByEmail(email.toLowerCase()).subscribe({
          next: (currentId: number) => this.checkResemblanceIdWithCurrent(currentId, id),
          error: () => alert("Don't have access")
        });
        this.subscription.push(subGetTrainerByIdEmail);
        break;
      default: alert("Don't have access");
    }
  }

  private checkResemblanceIdWithCurrent(currentId: number, id: number) {
    if (currentId == id) {
      this.routeOnEditTrainer(id);
    }
    else {
      alert("Don't have access");
    }
  }

  private routeOnEditTrainer(id: number): void {
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['trainer', 'edit-trainer', id] } }]);
  }

  ngOnDestroy(): void {
    this.subscription.forEach((x) => {
      x.unsubscribe()
    });
  }
  
}
