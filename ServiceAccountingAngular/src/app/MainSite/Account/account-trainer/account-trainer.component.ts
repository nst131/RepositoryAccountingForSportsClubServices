import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-account-trainer',
  templateUrl: './account-trainer.component.html',
  styleUrls: ['./account-trainer.component.css']
})
export class AccountTrainerComponent {

  constructor(private router: Router) { }

  public redirectOnCreateTrainingByClientCard() {
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['account-trainer', { outlets: { 'account': ['create-training-by-client-card'] } }] } }]);
  }

  public redirectOnCreateTrainingBySubscription() {
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['account-trainer', { outlets: { 'account': ['create-training-by-subscription'] } }] } }]);
  }

  public redirectOnShowAllTrainings() {
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['account-trainer', { outlets: { 'account': ['trainings'] } }] } }]);
  }
}
