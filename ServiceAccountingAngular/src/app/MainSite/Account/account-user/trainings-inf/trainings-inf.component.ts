import { Component, OnDestroy, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { TrainingInf } from '../models/training-inf.model';
import { AccountUserService } from '../services/account-user.service';

@Component({
  selector: 'app-trainings-inf',
  templateUrl: './trainings-inf.component.html',
  styleUrls: ['./trainings-inf.component.css'],
  providers: [AccountUserService]
})
export class TrainingsInfComponent implements OnInit, OnDestroy {

  @ViewChild('readOnlyTemplate', { static: false }) readOnlyTemplate!: TemplateRef<any>;
  public trainingsInfs: Array<TrainingInf>;
  public trainingsInfsName: Array<string>;
  public trainingsInfKeys: Array<string>;
  private subscription: Array<Subscription>;

  constructor(
    private accountUserService: AccountUserService,
    private activateRoute: ActivatedRoute) {

    this.trainingsInfs = new Array<TrainingInf>();
    this.trainingsInfsName = [];
    this.trainingsInfKeys = [];
    this.subscription = [];
  }

  public ngOnInit(): void {
    this.loadTrainingsInfs();
  }

  private loadTrainingsInfs(): void {
    let clientId: number = this.activateRoute.snapshot.params['id'];

    let subLoadTrainingsInfs: Subscription = this.accountUserService.getUserTrainingsInf(clientId).subscribe({
      next: (data: Array<TrainingInf>) => {
        this.trainingsInfsName = [];
        this.trainingsInfs = data;
        for (let key in data[0]) {
          this.trainingsInfsName.push(key.charAt(0).toUpperCase() + key.slice(1));
        }
      }
    })
    this.subscription.push(subLoadTrainingsInfs);
  }

  public loadTemplate(trainingsInf: any): TemplateRef<any> {
    this.trainingsInfKeys = [];
    for (const key in trainingsInf) {
      this.trainingsInfKeys.push(trainingsInf[key]);
    }
    return this.readOnlyTemplate;
  }

  ngOnDestroy(): void {
    this.subscription.forEach((x) => { x.unsubscribe() });
  }

}
