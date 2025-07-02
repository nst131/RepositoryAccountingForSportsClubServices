import { Component, OnDestroy, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthActivateService } from 'src/app/Auth/services/auth-activate.service';
import { Roles } from 'src/app/models/roles.enum';
import { ClubCard } from './models/club-card.model';
import { ClubCardService } from './services/club-card.service';

@Component({
  selector: 'app-club-card',
  templateUrl: './club-card.component.html',
  styleUrls: ['./club-card.component.css'],
  providers: [ClubCardService]
})
export class ClubCardComponent implements OnInit, OnDestroy {

  @ViewChild('readOnlyTemplate', { static: false }) readOnlyTemplate!: TemplateRef<any>;
  public clubCards: Array<ClubCard>;
  public clubCardsName: Array<string>;
  public clubCard: ClubCard;
  private subscription: Subscription[];

  constructor(private clubCardService: ClubCardService, private router: Router) {
    this.clubCards = new Array<ClubCard>();
    this.clubCardsName = [];
    this.clubCard = new ClubCard(Number.NaN,"","","","");
    this.subscription = [];
  }

  private loadClubCards(): void {
    let subLoadClubCards: Subscription = this.clubCardService.getClubCardces().subscribe({
      next: (data: Array<ClubCard>) => {
        this.clubCardsName = [];
        this.clubCards = data;
        for (let key in data[0]) {
          if (key == 'id') continue;

          this.clubCardsName.push(key.charAt(0).toUpperCase() + key.slice(1));
        }
      },
      error: (err) => {
        if (err.status == '403') {
          alert("Don't have acceess");
        }
        else {
          throw new Error("Cann't get ClubCards")
        }
      }
    })

    this.subscription.push(subLoadClubCards);
  }

  public deleteClubCard(id: number): void {
    let deleteClubCardSubscription = this.clubCardService.deleteClubCard(id).subscribe({
      next: () => { this.loadClubCards() },
      error: (err) => {
        if (err.status = '403')
          alert("Don't have access")
      },
    })

    this.subscription.push(deleteClubCardSubscription);
  }

  public ngOnInit(): void {
    this.loadClubCards();
  }

  public loadTemplate(clubCard: ClubCard): TemplateRef<any> {
    this.clubCard = clubCard;

    return this.readOnlyTemplate;
  }

  public redirectOnEditClubCard(id: number) {
    let role: string = AuthActivateService.getSession()?.role ?? "";
    if (role == "") {
      alert("Don't have access");
      return;
    }

    switch (role) {
      case Roles.Administrator:
        this.routeOnEditClubCard(id);
        break;
      default: alert("Don't have access");
    }
  }

  private routeOnEditClubCard(id: number): void {
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['club-card', 'edit-club-card', id] } }]);
  }

  ngOnDestroy(): void {
    this.subscription.forEach((x) => { x.unsubscribe() });
  }
}
