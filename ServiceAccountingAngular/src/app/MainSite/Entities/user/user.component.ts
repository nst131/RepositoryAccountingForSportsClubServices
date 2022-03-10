import { Component, OnDestroy, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthActivateService } from 'src/app/Auth/services/auth-activate.service';
import { Roles } from 'src/app/models/roles.enum'
import { User } from './models/user.model';
import { UserService } from './services/user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css'],
  providers: [UserService]
})
export class UserComponent implements OnInit, OnDestroy {
  
  @ViewChild('readOnlyTemplate', { static: false }) readOnlyTemplate!: TemplateRef<any>;
  public users: Array<User>;
  public usersName: Array<string>;
  public userKeys: Array<string>;
  private subscription: Subscription[];

  constructor(private userService: UserService, private router: Router) {
    this.users = new Array<User>();
    this.usersName = [];
    this.userKeys = [];
    this.subscription = [];
  }

  private loadUsers(): void {
    let subLoadUsers: Subscription = this.userService.getUsers().subscribe({
      next: (data: Array<User>) => {
        this.usersName = [];
        this.users = data;
        for (let key in data[0]) {
          if (key == 'id' || key == 'email') continue;

          this.usersName.push(key.charAt(0).toUpperCase() + key.slice(1));
        }
      },
      error: (err) => {
        if (err.status == '403') {
          alert("Don't have acceess");
        }
        else {
          throw new Error("Cann't get Users")
        }
      }
    })

    this.subscription.push(subLoadUsers);
  }

  public deleteUser(id: number): void {
    let deleteUserSubscription = this.userService.deleteUser(id).subscribe({
      next: () => { this.loadUsers() },
      error: (err) => {
        if (err.status = '403')
          alert("Don't have access")
      },
    })

    this.subscription.push(deleteUserSubscription);
  }

  public ngOnInit(): void {
    this.loadUsers();
  }

  public loadTemplate(user: any): TemplateRef<any> {
    this.userKeys = [];

    for (const key in user) {
      if (key == 'id' || key == 'email') continue;
      this.userKeys.push(user[key]);
    }

    return this.readOnlyTemplate;
  }

  public redirectOnEditUser(id: number) {
    let role: string = AuthActivateService.getSession()?.role ?? "";
    let email: string = AuthActivateService.getSession()?.email ?? "";
    if (role == "") {
      alert("Don't have access");
      return;
    }

    switch (role) {
      case Roles.Administrator:
        this.routeOnEditUser(id);
        break;
      case Roles.User:
        let subGetUserByIdEmail: Subscription = this.userService.getUserIdByEmail(email.toLowerCase()).subscribe({
          next: (currentId: number) => this.checkResemblanceIdWithCurrent(currentId, id),
          error: () => alert("Don't have access")
        });
        this.subscription.push(subGetUserByIdEmail);
        break;
      default: alert("Don't have access");
    }
  }

  private checkResemblanceIdWithCurrent(currentId: number, id: number) {
    if (currentId == id) {
      this.routeOnEditUser(id);
    }
    else {
      alert("Don't have access");
    }
  }

  private routeOnEditUser(id: number): void {
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['user', 'edit-user', id] } }]);
  }

  ngOnDestroy(): void {
    this.subscription.forEach((x) => { x.unsubscribe() });
  }
}
