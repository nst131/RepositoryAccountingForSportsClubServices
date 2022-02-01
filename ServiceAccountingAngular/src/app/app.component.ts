import { AfterViewChecked, ChangeDetectorRef, Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements AfterViewChecked {
  public auth: boolean = false;
  public mainSite: boolean = false;

  public currentPage: string = "";

  constructor(private router: Router, private cdRef: ChangeDetectorRef) { }

  ngAfterViewChecked(): void {
    // if(this.router.url == ""){
    //   console.log("Auth");
    //   this.auth = true;
    //   this.mainSite = false;
    // }

    // if(this.router.url == ""){
    //   console.log("MainSite");
    //   this.auth = false;
    //   this.mainSite = true;
    // }

    this.cdRef.detectChanges();
  }
}
