import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Login } from '../models';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
   private baseUrl: string;
   constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) { this.baseUrl = baseUrl; }
  getAll() {
       return this.http.get<Login[]>(this.baseUrl + 'users');
  }
}
