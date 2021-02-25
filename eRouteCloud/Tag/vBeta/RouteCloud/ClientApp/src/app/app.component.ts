import { Component } from '@angular/core';
import { Login } from './models';
import { Router } from '@angular/router';
import { AuthenticationService } from './services/index.service';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})

export class AppComponent {
    title = 'eRoute Cloud';
    currentUser: Login;

    constructor(
        private router: Router,
        private authenticationService: AuthenticationService
    ) {
        this.authenticationService.currentUser.subscribe((x: Login) => this.currentUser = x);
    }

    //get isAdmin() {
    //    return this.currentUser && this.currentUser.role === Role.Admin;
    //}

    logout() {
        this.authenticationService.logout();
        this.router.navigate(['/login']);
    }
}
