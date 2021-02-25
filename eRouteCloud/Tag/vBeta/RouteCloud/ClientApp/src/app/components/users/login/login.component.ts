import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs/operators';
import { AuthenticationService } from '../../../services/index.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
    loginForm: FormGroup;
    loading: boolean = false;
    submitted: boolean = false;
    returnUrl: string;
    error: string = '';
    hide: boolean = true;

    constructor(
        private formBuilder: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private authenticationService: AuthenticationService
    ) {
        // Redirect to home if already logged in
        if (this.authenticationService.currentUserValue) {
            this.router.navigate(['/']);
        }
    }

    ngOnInit() {
        this.loginForm = this.formBuilder.group({
            username: ['', [Validators.required]],
            password: ['', [Validators.required]]
        });
        // Get return url from route parameters or default to '/'
        this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    }

    // Get the error message required user
    getErrorMessageUser() {
        return this.formControl.username.hasError('required') ? 'Debes ingresar un usuario' : '';
    }

    // Get the error message required password
    getErrorMessagePassword() {
        return this.formControl.password.hasError('required') ? 'Debes ingresar la contraseña' : '';
    }

    // Convenience getter for easy access to form fields
    get formControl() { return this.loginForm.controls; }

    onSubmit() {
        this.submitted = true;

        // Stop here if "form" is invalid
        if (this.loginForm.invalid) {
            return;
        }

        this.loading = true;
        this.authenticationService.login(this.formControl.username.value, this.formControl.password.value)
            .pipe(first())
            .subscribe(
                () => {
                    this.router.navigate([this.returnUrl]);
                },
                (error: string) => {
                    this.error = error;
                    this.loading = false;
                });
    }
}
