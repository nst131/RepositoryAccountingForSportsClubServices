import { Injectable, Optional } from '@angular/core';
import { CanActivateChild, Router } from '@angular/router';
import { AuthActivateService } from './auth-activate.service';

@Injectable({
    providedIn: 'root'
})
export class AuthGuardService implements CanActivateChild {
    public attemts: number = 0;
    public bul: boolean = false;
    // export class AuthGuardService implements CanActivate {
    constructor(@Optional() private authActivateService: AuthActivateService, private router: Router) { }

    async canActivateChild() {
        // canActivate() {
        return await this.authActivateService.isLoggedIn()
            .then((isAuth) => {
                if (isAuth) {
                    return true;
                }
                this.authActivateService.redirectOnAuth();
                return false;
            });
    }
}