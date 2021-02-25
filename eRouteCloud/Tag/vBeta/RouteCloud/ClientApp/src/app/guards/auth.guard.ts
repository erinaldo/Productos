import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthenticationService } from '../services/index.service';

@Injectable({
    providedIn: 'root'
})

export class AuthGuard implements CanActivate {
    constructor(
        private router: Router,
        private authenticationService: AuthenticationService
    ) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        const CURRENTUSER = this.authenticationService.currentUserValue;
        if (CURRENTUSER) {
            return true;
        }
        this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } })
    }
}
