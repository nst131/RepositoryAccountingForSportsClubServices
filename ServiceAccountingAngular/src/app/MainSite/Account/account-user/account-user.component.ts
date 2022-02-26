import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { User } from '../../Entities/user/models/user.model';
import { UserService } from '../../Entities/user/services/user.service';

@Component({
  selector: 'app-account-user',
  templateUrl: './account-user.component.html',
  styleUrls: ['./account-user.component.css'],
  providers: [UserService]
})
export class AccountUserComponent implements OnInit {
  public user: User;
  public userId: number;
  private subscription: Subscription[];

  constructor(private userService: UserService) {
    this.user = new User(Number.NaN, "", "", "", "", "");
    this.subscription = [];
    this.userId = Number.NaN;
  }

  ngOnInit(): void {
    let getIdUserByEmailSubscription = this.userService.getUserIdByStorageEmail().subscribe({
      next: (id: number) => {
        this.userId = id;
        let getUserSubscription = this.userService.getUser(id).subscribe({
          next:(user: User) => { this.user = user}
        })

        this.subscription.push(getUserSubscription);
      },
      error: () => { console.log("Do not get id By Emal") },///////////////////////////////////////////////////////
    })
    
    this.subscription.push(getIdUserByEmailSubscription);
  }

}
