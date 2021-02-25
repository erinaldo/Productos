import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthenticationService } from '../services/index.service';
import { Injectable } from '@angular/core';

@Injectable()

export class JwtInterceptor implements HttpInterceptor {
    constructor( private authenticationService: AuthenticationService ) { }

    intercept( request: HttpRequest<any>, next: HttpHandler ): Observable< HttpEvent< any > > {
        const CURRENTUSER = this.authenticationService.currentUserValue;
        if ( CURRENTUSER && CURRENTUSER.token ) {
            request = request.clone({
                setHeaders: {
                    Authorization: `Bearer ${ CURRENTUSER.token }`
                }
            });
        }
        return next.handle(request);
    }
}
