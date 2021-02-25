//import { Injectable, Inject } from '@angular/core';
//import { HttpClient, HttpHeaders } from '@angular/common/http';
//import { map } from 'rxjs/operators';
//import { isNullOrUndefined } from 'util';
//import { UserInterface } from '../interface/user.interface';

//@Injectable({
//    providedIn: 'root'
//})
//export class AuthService {
//    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) { this.baseUrl = baseUrl }

//    private baseUrl: string;
//    private headers: HttpHeaders = new HttpHeaders({
//        "Content-Type": "application/json"
//    });

//    login(username: string, password: string) {
//        return this.http.post<UserInterface>(this.baseUrl + 'users/authenticate', { username, password }, { headers: this.headers })
//            .pipe(map(user => {
//                this.setUser(user);
//                return user;
//            }));
//    }

//    setUser(user: UserInterface): void {
//        localStorage.setItem('currentUser', JSON.stringify(user));
//    }

//    setToken(token): void {
//        localStorage.setItem('accessToken', JSON.stringify(token));
//    }

//    getToken() {
//        return localStorage.getItem('accessToken');
//    }

//    getCurrentUser(): UserInterface {
//        const CURRENT_USER = localStorage.getItem('currentUser')
//        if (!isNullOrUndefined(CURRENT_USER)) {
//            return JSON.parse(CURRENT_USER);
//        } else {
//            return null;
//        }
//    }

//    logout() {
//        return this.http.post<UserInterface>(this.baseUrl + 'users/logout', this.getToken(), { headers: this.headers });
//    }
//}
