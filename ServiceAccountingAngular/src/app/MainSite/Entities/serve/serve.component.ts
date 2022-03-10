import { Component, OnDestroy, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthActivateService } from 'src/app/Auth/services/auth-activate.service';
import { Roles } from 'src/app/models/roles.enum';
import { Serve } from './model/serve.model';
import { ServeService } from './services/serve.service';

@Component({
  selector: 'app-serve',
  templateUrl: './serve.component.html',
  styleUrls: ['./serve.component.css'],
  providers: [ServeService]
})
export class ServeComponent implements OnInit, OnDestroy {

  @ViewChild('readOnlyTemplate', { static: false }) readOnlyTemplate!: TemplateRef<any>;
  public serves: Array<Serve>;
  public servesName: Array<string>;
  public serve: Serve;
  private subscription: Subscription[];

  constructor(private serveService: ServeService, private router: Router) {
    this.serves = new Array<Serve>();
    this.servesName = [];
    this.serve = new Serve(Number.NaN,"","","","");
    this.subscription = [];
  }

  private loadServes(): void {
    let subLoadServes: Subscription = this.serveService.getServeces().subscribe({
      next: (data: Array<Serve>) => {
        this.servesName = [];
        this.serves = data;
        for (let key in data[0]) {
          if (key == 'id') continue;

          this.servesName.push(key.charAt(0).toUpperCase() + key.slice(1));
        }
      },
      error: (err) => {
        if (err.status == '403') {
          alert("Don't have acceess");
        }
        else {
          throw new Error("Cann't get Serves")
        }
      }
    })

    this.subscription.push(subLoadServes);
  }

  public deleteServe(id: number): void {
    let deleteServeSubscription = this.serveService.deleteServe(id).subscribe({
      next: () => { this.loadServes() },
      error: (err) => {
        if (err.status = '403')
          alert("Don't have access")
      },
    })

    this.subscription.push(deleteServeSubscription);
  }

  public ngOnInit(): void {
    this.loadServes();
  }

  public loadTemplate(serve: Serve): TemplateRef<any> {
    this.serve = serve;

    return this.readOnlyTemplate;
  }

  public redirectOnEditServe(id: number) {
    let role: string = AuthActivateService.getSession()?.role ?? "";
    if (role == "") {
      alert("Don't have access");
      return;
    }

    switch (role) {
      case Roles.Administrator:
        this.routeOnEditServe(id);
        break;
      default: alert("Don't have access");
    }
  }

  private routeOnEditServe(id: number): void {
    this.router.navigate(['/main-site', { outlets: { 'main-site': ['service', 'edit-serve', id] } }]);
  }

  ngOnDestroy(): void {
    this.subscription.forEach((x) => { x.unsubscribe() });
  }

}
